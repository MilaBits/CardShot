/* 
 * author : jiankaiwang
 * description : The script provides you with basic operations of first personal control.
 * platform : Unity
 * date : 2017/12
 */

using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Experimental.Input.Plugins.PlayerInput;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerCharacterController))]
public class PlayerCharacterController : MonoBehaviour {

    private InputActionMap actionMap;

    [SerializeField]
    private Player player;

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
    

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void Start() {
        // hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        Move();
    }

    private void Move() {
        Vector3 move = new Vector3(Input.GetAxis($"Horizontal{player.ControlSuffix}"), 0 ,Input.GetAxis($"Vertical{player.ControlSuffix}"));
        
        if (CheckForWall()) {
            move = Vector3.zero;
        }
        else {
            transform.Translate(move.normalized * speed * Time.deltaTime);
        }

        if (Input.GetButtonDown($"Jump{player.ControlSuffix}")) Jump();

        //TODO: Turn into new input
        if (Input.GetKeyDown("escape")) {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Jump() {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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