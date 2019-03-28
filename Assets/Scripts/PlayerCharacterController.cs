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
public class PlayerCharacterController : MonoBehaviour
{
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


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void Move()
    {
        Vector3 forwardVel = transform.forward * speed * Input.GetAxis($"Vertical{player.ControlSuffix}");
        Vector3 horizontalVel = transform.right * speed * Input.GetAxis($"Horizontal{player.ControlSuffix}");
        Vector3 verticalVel = transform.up * rb.velocity.y + Physics.gravity * Time.fixedDeltaTime;

        if (Input.GetButtonDown($"Jump{player.ControlSuffix}"))
        {
            verticalVel = transform.up * jumpForce;
        }

        rb.velocity = forwardVel + horizontalVel + verticalVel;


        //TODO: Turn into new input
        if (Input.GetKeyDown("escape"))
        {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }
}