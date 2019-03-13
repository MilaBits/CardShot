using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor {
    private float size = 1f;

    private void OnSceneGUI() {
        GameManager gameManager = (GameManager) target;

        // Draw spawn point
        Handles.color = Color.yellow;
        foreach (SpawnPoint spawnPoint in gameManager.SpawnPoints) {
            var position = spawnPoint.transform.position;
            var rotation = spawnPoint.transform.rotation;
            Handles.CircleHandleCap(0, position, rotation * Quaternion.LookRotation(Vector3.up), size,
                EventType.Repaint);
            Handles.DrawLine(position + rotation * new Vector3(size / 2, 0, 0),
                position + rotation * Vector3.forward * size);
            Handles.DrawLine(position + rotation * new Vector3(-size / 2, 0, 0),
                position + rotation * Vector3.forward * size);
            Handles.DrawLine(position + rotation * new Vector3(size / 2, 0, 0),
                position + rotation * new Vector3(-size / 2, 0, 0));
            Handles.DrawLine(position, position + rotation * Vector3.back * size);
        }
    }

    private void OnValidate() {
        GameManager gameManager = (GameManager) target;

        if (gameManager.transform.childCount != gameManager.SpawnPoints.Count) {
            gameManager.SpawnPoints.Clear();
            for (int i = 0; i < gameManager.transform.childCount; i++) {
                gameManager.SpawnPoints.Add(gameManager.transform.GetChild(i).GetComponent<SpawnPoint>());
            }
        }
    }
}