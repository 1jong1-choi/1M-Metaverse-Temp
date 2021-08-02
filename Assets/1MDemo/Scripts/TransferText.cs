using System;
using System.Collections;
using System.Collections.Generic;
using _1MDemo.Scripts;
using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using MLAPI.NetworkVariable.Collections;
using TMPro;
using UnityEngine;

namespace _1MDemo.Scripts
{
    public class TransferText : NetworkBehaviour
    {
        // private TMP_InputField textInputField;
        // private TMP_Text chatField;
        private String playerName;

        private NetworkVariableString chatMessages = new NetworkVariableString(
            new NetworkVariableSettings()
            {
                ReadPermission = NetworkVariablePermission.Everyone,
                WritePermission = NetworkVariablePermission.Everyone
            });

        private void Start()
        {
            // textInputField = GameObject.Find("InputField _TextChat").GetComponent<TMP_InputField>();
            // chatField = GameObject.Find("TextChat").GetComponent<TMP_Text>();
        }

        public override void NetworkStart()
        {
            if (!IsServer) { return; }

            PlayerData? playerData = PasswordNetworkManager.GetPlayerData(OwnerClientId);

            if(playerData.HasValue)
            {
                playerName = playerData.Value.PlayerName;
            }
        }

        [ServerRpc]
        public void SendTextServerRPC(string inputFieldText)
        {
            if(!IsServer) { return; }
            chatMessages.Value = playerName + " : " + inputFieldText + "\n";
            print("server " + chatMessages.Value);
            print("serverRPC");
            ShowTextClientRPC();
        }

        [ClientRpc]
        public void ShowTextClientRPC()
        {
            if(!IsClient) { return; }
            print("client " + chatMessages.Value);
            GameObject.Find("TextChat").GetComponent<TMP_Text>().text += chatMessages.Value;
            // GUILayout.Label(chatMessages.Value);
            print("clientRPC");
        }
    }
}
