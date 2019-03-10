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
    [SerializeField]
    private PlayerInput playerInput;

    private InputActionMap actionMap;

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

    private void OnEnable() {

        actionMap = playerInput.actions.GetActionMap(playerInput.defaultActionMap) ;
        
        controlsContainer.Controls.Player.Move.performed += Move;
        controlsContainer.Controls.Player.Move.cancelled += context => StopMoving();
        controlsContainer.Controls.Player.Move.Enable();

        controlsContainer.Controls.Player.Jump.performed += Jump;
        controlsContainer.Controls.Player.Jump.cancelled += Jump;
        controlsContainer.Controls.Player.Jump.Enable();

    }

    private void OnDisable() {
        controlsContainer.Controls.Player.Move.performed -= Move;
        controlsContainer.Controls.Player.Move.cancelled -= context => StopMoving();
        controlsContainer.Controls.Player.Move.Disable();

        controlsContainer.Controls.Player.Jump.performed -= Jump;
        controlsContainer.Controls.Player.Jump.cancelled -= Jump;        
        controlsContainer.Controls.Player.Jump.Disable();

    }

    void Start() {
        // hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Move(InputAction.CallbackContext context) {
        Vector2 movement = context.ReadValue<Vector2>();
        
        translation = movement.y * speed * Time.deltaTime;
        straffe = movement.x * speed * Time.deltaTime;
        
        if (CheckForWall()) {
            straffe = 0;
            translation = 0;
        }
        else {
            transform.Translate(straffe, 0, translation);
        }

        //TODO: Turn into new input
        if (Input.GetKeyDown("escape")) {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void StopMoving() {
        translation = 0;
        straffe = 0;
    }

    private void Jump(InputAction.CallbackContext context) {
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