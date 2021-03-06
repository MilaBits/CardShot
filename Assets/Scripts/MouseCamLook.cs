﻿/* 
 * author : jiankaiwang
 * description : The script provides you with basic operations 
 *               of first personal camera look on mouse moving.
 * platform : Unity
 * date : 2017/12
 */

using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Experimental.Input;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class MouseCamLook : MonoBehaviour {
    [SerializeField]
    private Player player;

    [SerializeField]
    public float sensitivity = 5.0f;

    public float GamepadSensitivity = .2f;

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

    // Use this for initialization
    void Start() {
        character = transform.parent.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate() {
        float x = Input.GetAxis($"Look_Horizontal{player.ControlSuffix}");
        float y = Input.GetAxis($"Look_Vertical{player.ControlSuffix}");

        var md = new Vector2(x, y);

        switch (player.Platform) {
            case Platform.Keyboard:
                md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
                break;
            case Platform.Ps4:
            case Platform.Xbox:
                md = Vector2.Scale(md, new Vector2(GamepadSensitivity * smoothing, GamepadSensitivity * smoothing));
                break;
        }
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