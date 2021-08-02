using System.Collections.Generic;
using System.Text;
using DapperDino.UMT.PlayerNames;
using MLAPI;
using TMPro;
using UnityEngine;

namespace _1MDemo.Scripts
{
    public class PasswordNetworkManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField passwordInputField;
        [SerializeField] private TMP_InputField nameInputField;
        [SerializeField] private GameObject textChatUI;
        [SerializeField] private GameObject passwordEntryUI;
        [SerializeField] private GameObject leaveButton;
        [SerializeField] private GameObject ChatButton;
        [SerializeField] private GameObject gamepadUI;

        private static Dictionary<ulong, PlayerData> clientData;

        private void Start()
        {
            NetworkManager.Singleton.OnServerStarted += this.HandleServerStarted;
            NetworkManager.Singleton.OnClientConnectedCallback += this.HandleClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback += this.HandleClientDisconnect;
        }

        private void OnDestroy()
        {
            // Prevent error in the editor
            if (NetworkManager.Singleton == null) { return; }

            NetworkManager.Singleton.OnServerStarted -= this.HandleServerStarted;
            NetworkManager.Singleton.OnClientConnectedCallback -= this.HandleClientConnected;
            NetworkManager.Singleton.OnClientDisconnectCallback -= this.HandleClientDisconnect;
        }

        public void Host()
        {
            clientData = new Dictionary<ulong, PlayerData>();
            clientData[NetworkManager.Singleton.LocalClientId] = new PlayerData(nameInputField.text);

            // Hook up password approval check
            NetworkManager.Singleton.ConnectionApprovalCallback += this.ApprovalCheck;
            NetworkManager.Singleton.StartHost(new Vector3(10f, 2f, 0f), Quaternion.Euler(0f, 135f, 0f));
        }

        public void Client()
        {
            var payload = JsonUtility.ToJson(new ConnectionPayload()
            {
                password = passwordInputField.text,
                playerName = nameInputField.text
            });

            byte[] payloadBytes = Encoding.ASCII.GetBytes(payload);

            // Set password ready to send to the server to validate
            NetworkManager.Singleton.NetworkConfig.ConnectionData = payloadBytes;

            NetworkManager.Singleton.StartClient();
        }

        public static PlayerData? GetPlayerData(ulong clientId)
        {
            if(clientData.TryGetValue(clientId, out PlayerData playerData))
            {
                return playerData;
            }

            return null;
        }

        public void Leave()
        {
            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.StopHost();
                NetworkManager.Singleton.ConnectionApprovalCallback -= this.ApprovalCheck;
            }
            else if (NetworkManager.Singleton.IsClient)
            {
                NetworkManager.Singleton.StopClient();
            }

            passwordEntryUI.SetActive(true);
            leaveButton.SetActive(false);
            textChatUI.SetActive(false);
            ChatButton.SetActive(false);

            if (Application.platform == RuntimePlatform.Android)
            {
                gamepadUI.SetActive(false);
            }
        }

        public void Chat()
        {
            if (textChatUI.activeSelf)
            {
                textChatUI.SetActive(false);
            }
            else
            {
                textChatUI.SetActive(true);
            }
        }

        private void HandleServerStarted()
        {
            // Temporary workaround to treat host as client
            if (NetworkManager.Singleton.IsHost)
            {
                this.HandleClientConnected(NetworkManager.Singleton.ServerClientId);
            }
        }

        private void HandleClientConnected(ulong clientId)
        {
            // Are we the client that is connecting?
            if (clientId == NetworkManager.Singleton.LocalClientId)
            {
                passwordEntryUI.SetActive(false);
                leaveButton.SetActive(true);
                ChatButton.SetActive(true);

                if (Application.platform == RuntimePlatform.Android)
                {
                    gamepadUI.SetActive(true);
                }
            }
        }

        private void HandleClientDisconnect(ulong clientId)
        {
            if(NetworkManager.Singleton.IsServer)
            {
                clientData.Remove(clientId);
            }

            // Are we the client that is disconnecting?
            if (clientId == NetworkManager.Singleton.LocalClientId)
            {
                passwordEntryUI.SetActive(true);
                leaveButton.SetActive(false);
                ChatButton.SetActive(false);

                if (Application.platform == RuntimePlatform.Android)
                {
                    gamepadUI.SetActive(false);
                }
            }
        }

        private void ApprovalCheck(byte[] connectionData, ulong clientId, MLAPI.NetworkManager.ConnectionApprovedDelegate callback)
        {
            string payload = Encoding.ASCII.GetString(connectionData);
            // string payload = Encoding.Default.GetString(connectionData);
            var connectionPayload = JsonUtility.FromJson<ConnectionPayload>(payload);

            bool approveConnection = connectionPayload.password == passwordInputField.text;

            Vector3 spawnPos = Vector3.zero;
            Quaternion spawnRot = Quaternion.identity;

            if(approveConnection)
            {
                switch (NetworkManager.Singleton.ConnectedClients.Count)
                {
                    case 1:
                        spawnPos = new Vector3(11f, 2f, 0f);
                        spawnRot = Quaternion.Euler(0f, 180f, 0f);
                        break;
                    case 2:
                        spawnPos = new Vector3(12f, 2f, 0f);
                        spawnRot = Quaternion.Euler(0f, 225, 0f);
                        break;
                }

                clientData[clientId] = new PlayerData(connectionPayload.playerName);
            }

            callback(true, null, approveConnection, spawnPos, spawnRot);
        }
    }
}
