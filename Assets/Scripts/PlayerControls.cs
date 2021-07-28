// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""ShipControls"",
            ""id"": ""96f838a1-d18b-4f8d-90b8-df3c8318d568"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Value"",
                    ""id"": ""d7bd25f7-5fc0-440b-a97b-1ebc915f6607"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateRight"",
                    ""type"": ""Button"",
                    ""id"": ""ff7a1552-1864-4424-98fb-3bc17a5bddf4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateLeft"",
                    ""type"": ""Button"",
                    ""id"": ""ce9103c2-cc54-4d1f-b735-7d6d9d27fe4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reverse"",
                    ""type"": ""Button"",
                    ""id"": ""2cb2c8d3-6379-44ef-a70c-a4986d259a52"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""2844d7e9-831d-4a3f-abae-0550a251fc11"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""331c6cab-0e29-44e5-9a37-4130dd54766d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76963858-0f0c-413f-8ff7-babbc5ade457"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea9f2f26-7b7d-4230-a2db-77d16fc2deea"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3889c99c-4df6-4541-9f39-975b97840cbe"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reverse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84505eee-c71d-401b-af79-d03dc5c75ea3"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ShipControls
        m_ShipControls = asset.FindActionMap("ShipControls", throwIfNotFound: true);
        m_ShipControls_Forward = m_ShipControls.FindAction("Forward", throwIfNotFound: true);
        m_ShipControls_RotateRight = m_ShipControls.FindAction("RotateRight", throwIfNotFound: true);
        m_ShipControls_RotateLeft = m_ShipControls.FindAction("RotateLeft", throwIfNotFound: true);
        m_ShipControls_Reverse = m_ShipControls.FindAction("Reverse", throwIfNotFound: true);
        m_ShipControls_Fire = m_ShipControls.FindAction("Fire", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // ShipControls
    private readonly InputActionMap m_ShipControls;
    private IShipControlsActions m_ShipControlsActionsCallbackInterface;
    private readonly InputAction m_ShipControls_Forward;
    private readonly InputAction m_ShipControls_RotateRight;
    private readonly InputAction m_ShipControls_RotateLeft;
    private readonly InputAction m_ShipControls_Reverse;
    private readonly InputAction m_ShipControls_Fire;
    public struct ShipControlsActions
    {
        private @PlayerControls m_Wrapper;
        public ShipControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_ShipControls_Forward;
        public InputAction @RotateRight => m_Wrapper.m_ShipControls_RotateRight;
        public InputAction @RotateLeft => m_Wrapper.m_ShipControls_RotateLeft;
        public InputAction @Reverse => m_Wrapper.m_ShipControls_Reverse;
        public InputAction @Fire => m_Wrapper.m_ShipControls_Fire;
        public InputActionMap Get() { return m_Wrapper.m_ShipControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ShipControlsActions set) { return set.Get(); }
        public void SetCallbacks(IShipControlsActions instance)
        {
            if (m_Wrapper.m_ShipControlsActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnForward;
                @RotateRight.started -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnRotateRight;
                @RotateRight.performed -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnRotateRight;
                @RotateRight.canceled -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnRotateRight;
                @RotateLeft.started -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.performed -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnRotateLeft;
                @RotateLeft.canceled -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnRotateLeft;
                @Reverse.started -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnReverse;
                @Reverse.performed -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnReverse;
                @Reverse.canceled -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnReverse;
                @Fire.started -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_ShipControlsActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_ShipControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @RotateRight.started += instance.OnRotateRight;
                @RotateRight.performed += instance.OnRotateRight;
                @RotateRight.canceled += instance.OnRotateRight;
                @RotateLeft.started += instance.OnRotateLeft;
                @RotateLeft.performed += instance.OnRotateLeft;
                @RotateLeft.canceled += instance.OnRotateLeft;
                @Reverse.started += instance.OnReverse;
                @Reverse.performed += instance.OnReverse;
                @Reverse.canceled += instance.OnReverse;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public ShipControlsActions @ShipControls => new ShipControlsActions(this);
    public interface IShipControlsActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnRotateRight(InputAction.CallbackContext context);
        void OnRotateLeft(InputAction.CallbackContext context);
        void OnReverse(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
}
