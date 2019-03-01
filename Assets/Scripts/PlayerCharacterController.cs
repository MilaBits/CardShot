/* 
 * author : jiankaiwang
 * description : The script provides you with basic operations of first personal control.
 * platform : Unity
 * date : 2017/12
 */

using System;
using System.Runtime.Remoting.Messaging;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Networking;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerCharacterController))]
public class PlayerCharacterController : MonoBehaviour {

    [SerializeField]
    private ControlsContainer controlsContainer;

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
        controlsContainer.Controls.Gameplay.Move.Enable();
        controlsContainer.Controls.Gameplay.Move.performed += Move;
        controlsContainer.Controls.Gameplay.Move.cancelled += Move;

        controlsContainer.Controls.Gameplay.Jump.Enable();
        controlsContainer.Controls.Gameplay.Jump.performed += Jump;
        controlsContainer.Controls.Gameplay.Jump.cancelled += Jump;
    }

    private void OnDisable() {
        controlsContainer.Controls.Gameplay.Move.Disable();
        controlsContainer.Controls.Gameplay.Move.performed -= Move;
        controlsContainer.Controls.Gameplay.Move.cancelled -= Move;

        controlsContainer.Controls.Gameplay.Jump.Disable();
        controlsContainer.Controls.Gameplay.Jump.performed -= Jump;
        controlsContainer.Controls.Gameplay.Jump.cancelled -= Jump;
    }

    // Use this for initialization
    void Start() {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Move(InputAction.CallbackContext context) {
        Vector2 movement = context.ReadValue<Vector2>();
        
        Debug.Log(movement);

        translation = movement.y * speed * Time.deltaTime;
        straffe = movement.x * speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update() {
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