/* 
 * author : jiankaiwang
 * description : The script provides you with basic operations 
 *               of first personal camera look on mouse moving.
 * platform : Unity
 * date : 2017/12
 */

using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class MouseCamLook : MonoBehaviour {
    [SerializeField, InlineEditor]
    private ControlsContainer controlsContainer;

    [SerializeField]
    public float sensitivity = 5.0f;

    [SerializeField]
    public float smoothing = 2.0f;

    // the chacter is the capsule
    private GameObject character;

    // get the incremental value of mouse moving
    private Vector2 mouseLook;

    // smooth the mouse moving
    private Vector2 smoothV;

    private Vector2 look;

    [SerializeField]
    private float VerticalUpLimit;

    [SerializeField]
    private float VerticalDownLimit;


    private void OnEnable() {
        controlsContainer.Controls.Gameplay.Look.Enable();
        controlsContainer.Controls.Gameplay.Look.performed += Look;
        controlsContainer.Controls.Gameplay.Look.cancelled += Look;
    }

    private void OnDisable() {
        controlsContainer.Controls.Gameplay.Look.Disable();
        controlsContainer.Controls.Gameplay.Look.performed -= Look;
        controlsContainer.Controls.Gameplay.Look.cancelled -= Look;
    }

    // Use this for initialization
    void Start() {
        character = transform.parent.gameObject;
    }

    private void Look(InputAction.CallbackContext context) {
        look = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update() {
        var md = new Vector2(look.x, look.y);
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // the interpolated float result between the two float values
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        // incrementally add to the camera look
        mouseLook += smoothV;

        // Clamp vertical camera movement
        mouseLook.y = Mathf.Clamp(mouseLook.y, VerticalUpLimit, VerticalDownLimit);
        // vector3.right means the x-axis
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
//        }
    }
}