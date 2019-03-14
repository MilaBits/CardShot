using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private Player PlayerPrefab;

    [SerializeField]
    private int playerLimit;

    [SerializeField]
    private List<Player> Players = new List<Player>();

    [SerializeField]
    public List<SpawnPoint> SpawnPoints;

    [SerializeField]
    private RenderTexture[] playerViews;


    private bool keyboardPlayerAdded;
    private bool gamepadPlayerAdded;
    private void Update() {
        if (Players.Count < playerLimit) {
            if (gamepadPlayerAdded && !keyboardPlayerAdded && Input.GetButtonDown("Jump_2_Keyboard")) {
                keyboardPlayerAdded = true;
                SpawnPlayer(Players.Count + 1, Platform.Keyboard);
            }

            if (!gamepadPlayerAdded && Input.GetButtonDown("Jump_1_Ps4")) {
                gamepadPlayerAdded = true;
                SpawnPlayer(Players.Count + 1, Platform.Ps4);
                return;
            }

            if (!gamepadPlayerAdded &&Input.GetButtonDown("Jump_1_Xbox")) {
                gamepadPlayerAdded = true;
                SpawnPlayer(Players.Count + 1, Platform.Xbox);
                return;
            }
        }
    }

    private void SpawnPlayer(int playerId, Platform platform) {
        SpawnPoint spawn = SpawnPoints[Random.Range(0, SpawnPoints.Count - 1)];
        Player player = Instantiate(PlayerPrefab, spawn.transform.position, spawn.transform.rotation);
        Players.Add(player);
        player.gameObject.name = $"Player {playerId}";
        player.PlayerNumber = playerId;
        player.Platform = platform;

        player.ControlSuffix = $"_{playerId}_{platform}";

        switch (playerId) {
            case 1:
                player.HUD.anchoredPosition = new Vector3(-205, -32, 0);
                break;
            case 2:
                player.HUD.anchoredPosition = new Vector3(205, -32, 0);
                break;
        }
        
        Debug.Log($"Player {playerId} Joined ({platform})");

        // Give player their screen
        player.Camera.targetTexture = playerViews[playerId - 1];
    }
}