using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[BoltGlobalBehaviour]
public class NetworkCallbacks : Bolt.GlobalEventListener {
    public override void SceneLoadLocalDone(string map) {
        // randomize a position
        var spawnPosition = new Vector3(0, 2, 0);

        // instantiate cube
        BoltNetwork.Instantiate(BoltPrefabs.Player, spawnPosition, Quaternion.identity);
    }
}