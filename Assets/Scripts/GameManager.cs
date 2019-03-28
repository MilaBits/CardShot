using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Input.Plugins.PlayerInput;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player PlayerPrefab;

    [SerializeField]
    private Material[] PlayerMaterials;

    [SerializeField]
    private SplitScreenUI splitScreenUI;

    [SerializeField]
    private int playerLimit;

    [SerializeField]
    private ScoreUI scoreUi;

    [SerializeField]
    private List<Player> Players = new List<Player>();

    [SerializeField]
    public List<SpawnPoint> SpawnPoints;

    [SerializeField]
    private RenderTexture[] playerViews;

    private bool playing = false;

    [SerializeField, BoxGroup("Round")]
    private int RoundDuration;

    [SerializeField, BoxGroup("Round"), ReadOnly]
    private float RoundTimeLeft;

    private bool keyboardPlayerAdded;
    private bool gamepadPlayerAdded;

    [SerializeField]
    private int RefreshInterval;

    private void Update()
    {
        if (playing)
        {
            RoundTimeLeft -= Time.deltaTime;

//            // Refresh hands every x seconds
//            if ((int) RoundTimeLeft % RefreshInterval == 1)
//            {
//                foreach (Player player in Players)
//                {
//                    player.CardManager.FillHand();
//                }
//            } 

            scoreUi.SetRoundTime((int) Math.Floor(RoundTimeLeft));
        }


        if (Players.Count < playerLimit)
        {
            if (gamepadPlayerAdded && !keyboardPlayerAdded && Input.GetButtonDown("Jump_2_Keyboard"))
            {
                keyboardPlayerAdded = true;
                SpawnPlayer(Players.Count + 1, Platform.Keyboard);
            }

            if (!gamepadPlayerAdded && Input.GetButtonDown("Jump_1_Ps4"))
            {
                gamepadPlayerAdded = true;
                SpawnPlayer(Players.Count + 1, Platform.Ps4);
                return;
            }

            if (!gamepadPlayerAdded && Input.GetButtonDown("Jump_1_Xbox"))
            {
                gamepadPlayerAdded = true;
                SpawnPlayer(Players.Count + 1, Platform.Xbox);
                return;
            }
        }

        if (!playing && Players.Count == playerLimit && Players.TrueForAll(p => p.Ready)) StartRound();
    }

    private void StartRound(float delay)
    {
        StartCoroutine(DelayedRound(delay));
    }

    IEnumerator DelayedRound(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartRound();
    }

    private void StartRound()
    {
        foreach (SpawnPoint spawnPoint in SpawnPoints)
        {
            spawnPoint.Spawned = false;
        }

        splitScreenUI.FadeIn();
        playing = true;
        RoundTimeLeft = RoundDuration;

        ResetPlayers();

        foreach (Player player in Players)
        {
            splitScreenUI.PlayerStates[player.PlayerNumber - 1].SetState(PlayerState.Playing);
            
            int r;

            do
            {
                r = Random.Range(0, SpawnPoints.Count - 1);
            } while (SpawnPoints[r].Spawned);

            SpawnPoints[r].Spawned = true;

            player.transform.SetPositionAndRotation(
                SpawnPoints[r].transform.position,
                SpawnPoints[r].transform.rotation);
        }
    }

    private void ResetPlayers()
    {
        foreach (Player player in Players)
        {
            player.Reset();
            splitScreenUI.PlayerStates[player.PlayerNumber - 1].SetState(PlayerState.Readying);

            scoreUi.ResetRoundState();
        }
    }

    private void SpawnPlayer(int playerId, Platform platform)
    {
        SpawnPoint spawn = SpawnPoints[Random.Range(0, SpawnPoints.Count - 1)];
        Player player = Instantiate(PlayerPrefab, spawn.transform.position, spawn.transform.rotation);
        Players.Add(player);
        player.gameObject.name = $"Player {playerId}";
        player.MeshRenderer.material = PlayerMaterials[playerId - 1];
        player.PlayerNumber = playerId;
        player.Platform = platform;
        player.ControlSuffix = $"_{playerId}_{platform}";

        player.Health.OnDeath.AddListener(splitScreenUI.FadeOut);
        player.Health.OnDeath.AddListener(delegate { StartRound(2f); });

        switch (playerId)
        {
            case 1:
                player.Health.OnDamage.AddListener(delegate
                {
                    scoreUi.SetRoundState(Team.Blue, player.Health.getHealth());
                });
                player.Health.OnDeath.AddListener(delegate { scoreUi.AddScore(Team.Red); });

                player.HUD.anchoredPosition = new Vector3(-205, -32, 0);
                break;
            case 2:
                player.Health.OnDamage.AddListener(delegate
                {
                    scoreUi.SetRoundState(Team.Red, player.Health.getHealth());
                });
                player.Health.OnDeath.AddListener(delegate { scoreUi.AddScore(Team.Blue); });

                player.HUD.anchoredPosition = new Vector3(205, -32, 0);
                break;
        }

        Debug.Log($"Player {playerId} Joined ({platform})");

        // Give player their screen
        player.Camera.targetTexture = playerViews[playerId - 1];

        splitScreenUI.PlayerStates[playerId - 1].SetState(PlayerState.Readying);
    }
}