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
        // Gameplay
        m_Gameplay = asset.GetActionMap("Gameplay");
        m_Gameplay_Move = m_Gameplay.GetAction("Move");
        m_Gameplay_Look = m_Gameplay.GetAction("Look");
        m_Gameplay_Shoot = m_Gameplay.GetAction("Shoot");
        m_Gameplay_Card1 = m_Gameplay.GetAction("Card 1");
        m_Gameplay_Card2 = m_Gameplay.GetAction("Card 2");
        m_Gameplay_Card3 = m_Gameplay.GetAction("Card 3");
        m_Gameplay_Card4 = m_Gameplay.GetAction("Card 4");
        m_Gameplay_Jump = m_Gameplay.GetAction("Jump");
        // PS4
        m_PS4 = asset.GetActionMap("PS4");
        m_PS4_Move = m_PS4.GetAction("Move");
        m_PS4_Look = m_PS4.GetAction("Look");
        m_PS4_Shoot = m_PS4.GetAction("Shoot");
        m_PS4_Card1 = m_PS4.GetAction("Card 1");
        m_PS4_Card2 = m_PS4.GetAction("Card 2");
        m_PS4_Card3 = m_PS4.GetAction("Card 3");
        m_PS4_Card4 = m_PS4.GetAction("Card 4");
        // Xbox360
        m_Xbox360 = asset.GetActionMap("Xbox360");
        m_Xbox360_Move = m_Xbox360.GetAction("Move");
        m_Xbox360_Shoot = m_Xbox360.GetAction("Shoot");
        m_Xbox360_Card1 = m_Xbox360.GetAction("Card 1");
        m_Xbox360_Card2 = m_Xbox360.GetAction("Card 2");
        m_Xbox360_Card3 = m_Xbox360.GetAction("Card 3");
        m_Xbox360_Card4 = m_Xbox360.GetAction("Card 4");
        m_Xbox360_Card5 = m_Xbox360.GetAction("Card 5");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_Gameplay = null;
        m_Gameplay_Move = null;
        m_Gameplay_Look = null;
        m_Gameplay_Shoot = null;
        m_Gameplay_Card1 = null;
        m_Gameplay_Card2 = null;
        m_Gameplay_Card3 = null;
        m_Gameplay_Card4 = null;
        m_Gameplay_Jump = null;
        m_PS4 = null;
        m_PS4_Move = null;
        m_PS4_Look = null;
        m_PS4_Shoot = null;
        m_PS4_Card1 = null;
        m_PS4_Card2 = null;
        m_PS4_Card3 = null;
        m_PS4_Card4 = null;
        m_Xbox360 = null;
        m_Xbox360_Move = null;
        m_Xbox360_Shoot = null;
        m_Xbox360_Card1 = null;
        m_Xbox360_Card2 = null;
        m_Xbox360_Card3 = null;
        m_Xbox360_Card4 = null;
        m_Xbox360_Card5 = null;
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
    // Gameplay
    private InputActionMap m_Gameplay;
    private InputAction m_Gameplay_Move;
    private InputAction m_Gameplay_Look;
    private InputAction m_Gameplay_Shoot;
    private InputAction m_Gameplay_Card1;
    private InputAction m_Gameplay_Card2;
    private InputAction m_Gameplay_Card3;
    private InputAction m_Gameplay_Card4;
    private InputAction m_Gameplay_Jump;
    public struct GameplayActions
    {
        private DefaultInputActions m_Wrapper;
        public GameplayActions(DefaultInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move { get { return m_Wrapper.m_Gameplay_Move; } }
        public InputAction @Look { get { return m_Wrapper.m_Gameplay_Look; } }
        public InputAction @Shoot { get { return m_Wrapper.m_Gameplay_Shoot; } }
        public InputAction @Card1 { get { return m_Wrapper.m_Gameplay_Card1; } }
        public InputAction @Card2 { get { return m_Wrapper.m_Gameplay_Card2; } }
        public InputAction @Card3 { get { return m_Wrapper.m_Gameplay_Card3; } }
        public InputAction @Card4 { get { return m_Wrapper.m_Gameplay_Card4; } }
        public InputAction @Jump { get { return m_Wrapper.m_Gameplay_Jump; } }
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
    }
    public GameplayActions @Gameplay
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new GameplayActions(this);
        }
    }
    // PS4
    private InputActionMap m_PS4;
    private InputAction m_PS4_Move;
    private InputAction m_PS4_Look;
    private InputAction m_PS4_Shoot;
    private InputAction m_PS4_Card1;
    private InputAction m_PS4_Card2;
    private InputAction m_PS4_Card3;
    private InputAction m_PS4_Card4;
    public struct PS4Actions
    {
        private DefaultInputActions m_Wrapper;
        public PS4Actions(DefaultInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move { get { return m_Wrapper.m_PS4_Move; } }
        public InputAction @Look { get { return m_Wrapper.m_PS4_Look; } }
        public InputAction @Shoot { get { return m_Wrapper.m_PS4_Shoot; } }
        public InputAction @Card1 { get { return m_Wrapper.m_PS4_Card1; } }
        public InputAction @Card2 { get { return m_Wrapper.m_PS4_Card2; } }
        public InputAction @Card3 { get { return m_Wrapper.m_PS4_Card3; } }
        public InputAction @Card4 { get { return m_Wrapper.m_PS4_Card4; } }
        public InputActionMap Get() { return m_Wrapper.m_PS4; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(PS4Actions set) { return set.Get(); }
    }
    public PS4Actions @PS4
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new PS4Actions(this);
        }
    }
    // Xbox360
    private InputActionMap m_Xbox360;
    private InputAction m_Xbox360_Move;
    private InputAction m_Xbox360_Shoot;
    private InputAction m_Xbox360_Card1;
    private InputAction m_Xbox360_Card2;
    private InputAction m_Xbox360_Card3;
    private InputAction m_Xbox360_Card4;
    private InputAction m_Xbox360_Card5;
    public struct Xbox360Actions
    {
        private DefaultInputActions m_Wrapper;
        public Xbox360Actions(DefaultInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move { get { return m_Wrapper.m_Xbox360_Move; } }
        public InputAction @Shoot { get { return m_Wrapper.m_Xbox360_Shoot; } }
        public InputAction @Card1 { get { return m_Wrapper.m_Xbox360_Card1; } }
        public InputAction @Card2 { get { return m_Wrapper.m_Xbox360_Card2; } }
        public InputAction @Card3 { get { return m_Wrapper.m_Xbox360_Card3; } }
        public InputAction @Card4 { get { return m_Wrapper.m_Xbox360_Card4; } }
        public InputAction @Card5 { get { return m_Wrapper.m_Xbox360_Card5; } }
        public InputActionMap Get() { return m_Wrapper.m_Xbox360; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(Xbox360Actions set) { return set.Get(); }
    }
    public Xbox360Actions @Xbox360
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new Xbox360Actions(this);
        }
    }
}
