using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnPoint))]
[CanEditMultipleObjects]
public class SpawnPointEditor : Editor {
    private float size = 1f;
    private void OnSceneGUI() {
        SpawnPoint spawnPoint = (SpawnPoint) target;

        // Draw spawn points
        Handles.color = Color.yellow;
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
        Handles.DrawLine(position, p2: position + rotation * Vector3.back * size);
    }
}