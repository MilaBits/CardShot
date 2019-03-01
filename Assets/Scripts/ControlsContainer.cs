using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class ControlsContainer : MonoBehaviour {
    [SerializeField, EnumToggleButtons]
    private InputType inputType;

    [SerializeField]
    public DefaultInputActions Controls;

    private enum InputType {
        Keyboard,
        Ps4,
        Xbox
    }
}