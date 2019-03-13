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

    private void Update() {
        if (Players.Count < playerLimit) {
            if (Input.GetButtonDown("Jump_1_Keyboard")) {
                SpawnPlayer(Players.Count, "Keyboard");
            }

            if (Input.GetButtonDown("Jump_1_Ps4")) {
                SpawnPlayer(Players.Count, "Ps4");
            }
        }
    }

    private void SpawnPlayer(int playerId, string platform) {
        SpawnPoint spawn = SpawnPoints[Random.Range(0, SpawnPoints.Count - 1)];
        Player player = Instantiate(PlayerPrefab, spawn.transform.position, spawn.transform.rotation);
        Players.Add(player);
        player.playerNumber = playerId;

        player.ControlSuffix = $"_{playerId+1}_{platform}";

        // Give player their screen
        player.camera.targetTexture = playerViews[playerId];
    }
}