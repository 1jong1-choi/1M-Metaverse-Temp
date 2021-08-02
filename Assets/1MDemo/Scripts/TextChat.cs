using System;
using System.Linq;
using MLAPI;
using MLAPI.Connection;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using MLAPI.NetworkVariable.Collections;
using TMPro;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.UI;

namespace _1MDemo.Scripts
{
    public class TextChat : MonoBehaviour
    {
        [SerializeField] private TMP_InputField textInputField;
        [SerializeField] private TMP_Text chatField;

        public void SendText()
        {
            ulong localClientId = NetworkManager.Singleton.LocalClientId;

            if (!NetworkManager.Singleton.ConnectedClients.TryGetValue(localClientId, out NetworkClient networkClient))
            {
                return;
            }

            if (!networkClient.PlayerObject.TryGetComponent<TransferText>(out var playerChat))
            {
                return;
            }

            if (textInputField.text != "")
            {
                playerChat.SendTextServerRPC(textInputField.text);
            }

            textInputField.text = "";

            textInputField.ActivateInputField();
        }

        // private void Update()
        // {
        //     if(Input.GetKeyDown(KeyCode.Return))
        //     {
        //         this.SendText();
        //     }
        // }
    }
}
