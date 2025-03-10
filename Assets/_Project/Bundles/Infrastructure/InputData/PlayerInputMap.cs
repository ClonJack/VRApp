//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/_Project/Bundles/Infrastructure/InputData/PlayerInputMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace UnrealTeam.VR.Input
{
    public partial class @PlayerInputMap: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputMap()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputMap"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""1940a918-c141-493d-a152-34d39fd6e733"",
            ""actions"": [
                {
                    ""name"": ""Keyboard"",
                    ""type"": ""Button"",
                    ""id"": ""c7bc46c5-2ac8-4114-a1e0-e9ed84bd85ef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NavigateY"",
                    ""type"": ""Value"",
                    ""id"": ""8578807d-56bd-4d08-99b1-a7437444e84c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""NavigateX"",
                    ""type"": ""Value"",
                    ""id"": ""afa3f0ab-50cf-487d-b493-7ccc11380b3b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""NavigateSelect"",
                    ""type"": ""Button"",
                    ""id"": ""0bfade05-5014-4e15-8314-e23d5d5943b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2fac1533-d6bf-4706-bab8-0a176583689a"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Keyboard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""YAxis"",
                    ""id"": ""f27aebc5-3696-43ff-ba6b-220974b8da37"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""71d3dd24-83cc-40e1-bc44-e3567e87d8d0"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f08291cc-76fc-477f-b62a-4594167aa5fc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""XAxis"",
                    ""id"": ""be205344-9a34-487b-b056-5ca95d63f625"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""1279acdf-572a-42e7-b369-e20a9b3d6532"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""67604c59-4557-428d-a552-43b40e0e5f9d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ea0b2c03-dae5-4236-889c-26736b8f66cb"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavigateSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_Keyboard = m_Player.FindAction("Keyboard", throwIfNotFound: true);
            m_Player_NavigateY = m_Player.FindAction("NavigateY", throwIfNotFound: true);
            m_Player_NavigateX = m_Player.FindAction("NavigateX", throwIfNotFound: true);
            m_Player_NavigateSelect = m_Player.FindAction("NavigateSelect", throwIfNotFound: true);
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

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Player
        private readonly InputActionMap m_Player;
        private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
        private readonly InputAction m_Player_Keyboard;
        private readonly InputAction m_Player_NavigateY;
        private readonly InputAction m_Player_NavigateX;
        private readonly InputAction m_Player_NavigateSelect;
        public struct PlayerActions
        {
            private @PlayerInputMap m_Wrapper;
            public PlayerActions(@PlayerInputMap wrapper) { m_Wrapper = wrapper; }
            public InputAction @Keyboard => m_Wrapper.m_Player_Keyboard;
            public InputAction @NavigateY => m_Wrapper.m_Player_NavigateY;
            public InputAction @NavigateX => m_Wrapper.m_Player_NavigateX;
            public InputAction @NavigateSelect => m_Wrapper.m_Player_NavigateSelect;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
                @Keyboard.started += instance.OnKeyboard;
                @Keyboard.performed += instance.OnKeyboard;
                @Keyboard.canceled += instance.OnKeyboard;
                @NavigateY.started += instance.OnNavigateY;
                @NavigateY.performed += instance.OnNavigateY;
                @NavigateY.canceled += instance.OnNavigateY;
                @NavigateX.started += instance.OnNavigateX;
                @NavigateX.performed += instance.OnNavigateX;
                @NavigateX.canceled += instance.OnNavigateX;
                @NavigateSelect.started += instance.OnNavigateSelect;
                @NavigateSelect.performed += instance.OnNavigateSelect;
                @NavigateSelect.canceled += instance.OnNavigateSelect;
            }

            private void UnregisterCallbacks(IPlayerActions instance)
            {
                @Keyboard.started -= instance.OnKeyboard;
                @Keyboard.performed -= instance.OnKeyboard;
                @Keyboard.canceled -= instance.OnKeyboard;
                @NavigateY.started -= instance.OnNavigateY;
                @NavigateY.performed -= instance.OnNavigateY;
                @NavigateY.canceled -= instance.OnNavigateY;
                @NavigateX.started -= instance.OnNavigateX;
                @NavigateX.performed -= instance.OnNavigateX;
                @NavigateX.canceled -= instance.OnNavigateX;
                @NavigateSelect.started -= instance.OnNavigateSelect;
                @NavigateSelect.performed -= instance.OnNavigateSelect;
                @NavigateSelect.canceled -= instance.OnNavigateSelect;
            }

            public void RemoveCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        public interface IPlayerActions
        {
            void OnKeyboard(InputAction.CallbackContext context);
            void OnNavigateY(InputAction.CallbackContext context);
            void OnNavigateX(InputAction.CallbackContext context);
            void OnNavigateSelect(InputAction.CallbackContext context);
        }
    }
}
