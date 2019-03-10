// GENERATED AUTOMATICALLY FROM 'Assets/Input/DefaultInputActions.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class DefaultInputActions : InputActionAssetReference
{
    public DefaultInputActions()
    {
    }
    public DefaultInputActions(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // Player
        m_Player = asset.GetActionMap("Player");
        m_Player_Move = m_Player.GetAction("Move");
        m_Player_Look = m_Player.GetAction("Look");
        m_Player_Shoot = m_Player.GetAction("Shoot");
        m_Player_Card1 = m_Player.GetAction("Card 1");
        m_Player_Card2 = m_Player.GetAction("Card 2");
        m_Player_Card3 = m_Player.GetAction("Card 3");
        m_Player_Card4 = m_Player.GetAction("Card 4");
        m_Player_Jump = m_Player.GetAction("Jump");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_Player = null;
        m_Player_Move = null;
        m_Player_Look = null;
        m_Player_Shoot = null;
        m_Player_Card1 = null;
        m_Player_Card2 = null;
        m_Player_Card3 = null;
        m_Player_Card4 = null;
        m_Player_Jump = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Player
    private InputActionMap m_Player;
    private InputAction m_Player_Move;
    private InputAction m_Player_Look;
    private InputAction m_Player_Shoot;
    private InputAction m_Player_Card1;
    private InputAction m_Player_Card2;
    private InputAction m_Player_Card3;
    private InputAction m_Player_Card4;
    private InputAction m_Player_Jump;
    public struct PlayerActions
    {
        private DefaultInputActions m_Wrapper;
        public PlayerActions(DefaultInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move { get { return m_Wrapper.m_Player_Move; } }
        public InputAction @Look { get { return m_Wrapper.m_Player_Look; } }
        public InputAction @Shoot { get { return m_Wrapper.m_Player_Shoot; } }
        public InputAction @Card1 { get { return m_Wrapper.m_Player_Card1; } }
        public InputAction @Card2 { get { return m_Wrapper.m_Player_Card2; } }
        public InputAction @Card3 { get { return m_Wrapper.m_Player_Card3; } }
        public InputAction @Card4 { get { return m_Wrapper.m_Player_Card4; } }
        public InputAction @Jump { get { return m_Wrapper.m_Player_Jump; } }
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
    }
    public PlayerActions @Player
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new PlayerActions(this);
        }
    }
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get

        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.GetControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get

        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.GetControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
}
