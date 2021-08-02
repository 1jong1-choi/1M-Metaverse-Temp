using System;
using MLAPI;
using MLAPI.NetworkVariable;
using TMPro;
using UnityEngine;

namespace _1MDemo.Scripts
{
    public class PlayerOverheadDisplay : NetworkBehaviour
    {
        [SerializeField] private TMP_Text displayNameText;

        private NetworkVariableString displayName = new NetworkVariableString();
        private Transform cameraAngle;

        private void Start()
        {
            cameraAngle = FindObjectOfType<Camera>().transform;
        }

        public override void NetworkStart()
        {
            if (!IsServer) { return; }

            PlayerData? playerData = PasswordNetworkManager.GetPlayerData(OwnerClientId);

            if(playerData.HasValue)
            {
                displayName.Value = playerData.Value.PlayerName;
            }
        }

        private void OnEnable()
        {
            displayName.OnValueChanged += this.HandleDisplayNameChanged;
        }

        private void OnDisable()
        {
            displayName.OnValueChanged -= this.HandleDisplayNameChanged;
        }

        private void HandleDisplayNameChanged(string oldDisplayName, string newDisplayName)
        {
            displayNameText.text = newDisplayName;
        }

        private void Update()
        {
            transform.LookAt(cameraAngle);
        }
    }
}
