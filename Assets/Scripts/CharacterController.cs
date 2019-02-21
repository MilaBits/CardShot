/* 
 * author : jiankaiwang
 * description : The script provides you with basic operations of first personal control.
 * platform : Unity
 * date : 2017/12
 */

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]
public class CharacterController : MonoBehaviour {
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

    [FormerlySerializedAs("networkPlayer")]
    [SerializeField]
    private NetworkIdentity userId;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start() {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update() {
        if (userId.isLocalPlayer) {
            // Input.GetAxis() is used to get the user's input
            // You can furthor set it on Unity. (Edit, Project Settings, Input)
            translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            if (CheckForWall()) {
                straffe = 0;
                translation = 0;
            }
            else {
                transform.Translate(straffe, 0, translation);
            }

            if (Input.GetKeyDown("escape")) {
                // turn on the cursor
                Cursor.lockState = CursorLockMode.None;
            }

            if (Input.GetButtonDown("Jump")) {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    private bool CheckForWall() {
        Vector3 dir = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(straffe, 0, translation);

        RaycastHit hit;
        Physics.Raycast(transform.position + new Vector3(0, 1f, 0), dir, out hit, 0.6f, WallMask);
        if (hit.collider == null) {
            return false;
        }

        Debug.Log("Wall");
        return true;
    }

    private void FixedUpdate() {
        if (rb.velocity.y < 0) {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
}