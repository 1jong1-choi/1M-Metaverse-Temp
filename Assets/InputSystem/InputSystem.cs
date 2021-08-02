// GENERATED AUTOMATICALLY FROM 'Assets/InputSystem/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""PlayerMove"",
            ""id"": ""3a51b6be-fed5-4b39-b568-1e37107fea33"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""0528a10e-978b-45dc-8485-cdf85bb2b980"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""b7a475c9-2174-4977-8c9b-86e5040485d9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Value"",
                    ""id"": ""80c147d4-1356-4079-add0-69f775ec5770"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""61ee8042-7f85-4a3f-a61a-52ea2b43fc2e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8eb3d09f-1171-48c5-b97d-c570a3a94c29"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""685d65f2-230f-4231-8f76-40255f425952"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyborad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""19980e41-1fe5-48a4-a495-7a664fba460f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyborad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4f28fa6b-20ac-4c0f-90f1-67da3c2917e7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyborad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""28fc79d1-895c-48e8-aaba-28509ea58a1b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyborad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""29519eb7-2811-4e10-afb8-c78c4417d1f6"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""d3a0a1bf-a082-472e-9f0c-39138c32362d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f0f20836-ce0a-443c-8611-c7b273bfd585"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyborad"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7cdc180e-3738-40aa-93bb-6a62b5362edd"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyborad"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""df02342e-5baf-4e6c-aabf-3bb2d7a69a2d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""18d3ca9e-d1b1-4b79-bf4f-43e66f9b067b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""baaf9431-1624-47fb-a9e4-7cd9401688b3"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyborad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ab0797ff-1a37-4318-b94f-9d5d14a8801c"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyborad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d8718d85-94bd-419f-aa00-e58fc1c155f0"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d6ab164-906b-4012-8ac0-7490194767cc"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyborad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea130074-dd2e-4a07-968d-ef9f6275ff10"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepads"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepads"",
            ""bindingGroup"": ""Gamepads"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyborad"",
            ""bindingGroup"": ""Keyborad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerMove
        m_PlayerMove = asset.FindActionMap("PlayerMove", throwIfNotFound: true);
        m_PlayerMove_Move = m_PlayerMove.FindAction("Move", throwIfNotFound: true);
        m_PlayerMove_Jump = m_PlayerMove.FindAction("Jump", throwIfNotFound: true);
        m_PlayerMove_Sprint = m_PlayerMove.FindAction("Sprint", throwIfNotFound: true);
        m_PlayerMove_Look = m_PlayerMove.FindAction("Look", throwIfNotFound: true);
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

    // PlayerMove
    private readonly InputActionMap m_PlayerMove;
    private IPlayerMoveActions m_PlayerMoveActionsCallbackInterface;
    private readonly InputAction m_PlayerMove_Move;
    private readonly InputAction m_PlayerMove_Jump;
    private readonly InputAction m_PlayerMove_Sprint;
    private readonly InputAction m_PlayerMove_Look;
    public struct PlayerMoveActions
    {
        private @InputSystem m_Wrapper;
        public PlayerMoveActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMove_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerMove_Jump;
        public InputAction @Sprint => m_Wrapper.m_PlayerMove_Sprint;
        public InputAction @Look => m_Wrapper.m_PlayerMove_Look;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMove; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMoveActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMoveActions instance)
        {
            if (m_Wrapper.m_PlayerMoveActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnJump;
                @Sprint.started -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnSprint;
                @Sprint.performed -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnSprint;
                @Sprint.canceled -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnSprint;
                @Look.started -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerMoveActionsCallbackInterface.OnLook;
            }
            m_Wrapper.m_PlayerMoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
            }
        }
    }
    public PlayerMoveActions @PlayerMove => new PlayerMoveActions(this);
    private int m_GamepadsSchemeIndex = -1;
    public InputControlScheme GamepadsScheme
    {
        get
        {
            if (m_GamepadsSchemeIndex == -1) m_GamepadsSchemeIndex = asset.FindControlSchemeIndex("Gamepads");
            return asset.controlSchemes[m_GamepadsSchemeIndex];
        }
    }
    private int m_KeyboradSchemeIndex = -1;
    public InputControlScheme KeyboradScheme
    {
        get
        {
            if (m_KeyboradSchemeIndex == -1) m_KeyboradSchemeIndex = asset.FindControlSchemeIndex("Keyborad");
            return asset.controlSchemes[m_KeyboradSchemeIndex];
        }
    }
    public interface IPlayerMoveActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
    }
}
