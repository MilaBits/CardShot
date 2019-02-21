using Networking;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class CharacterInput {
    private PlayerBehaviour player;

    public CharacterInput(PlayerBehaviour player) {
        this.player = player;
        rb = player.GetComponent<Rigidbody>();
    }

    public float speed = 10.0f;
    private float translation;
    private float straffe;

    [SerializeField]
    private float jumpForce = 2.25f;

    [SerializeField]
    private float fallMultiplier = 2.25f;

    private Rigidbody rb;

    [SerializeField]
    private LayerMask WallMask;

    public void Move() {
        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        if (CheckForWall()) {
            straffe = 0;
            translation = 0;
        }
        else {
            player.transform.Translate(straffe, 0, translation);
        }

        if (Input.GetKeyDown("escape")) {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetButtonDown("Jump")) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool CheckForWall() {
        Vector3 dir = Quaternion.Euler(0, player.transform.eulerAngles.y, 0) * new Vector3(straffe, 0, translation);

        RaycastHit hit;
        Physics.Raycast(player.transform.position + new Vector3(0, 1f, 0), dir, out hit, 0.6f, WallMask);
        if (hit.collider == null) {
            return false;
        }

        Debug.Log("Wall");
        return true;
    }

    public void AdjustJumpGravity() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
}