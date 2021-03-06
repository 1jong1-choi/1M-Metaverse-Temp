using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine;

namespace DapperDino.UMT.NetworkVariables
{
    public class TeamPlayer : NetworkBehaviour
    {
        [SerializeField] private Renderer teamColourRenderer;
        [SerializeField] private Color[] teamColours;

        private NetworkVariableByte teamIndex = new NetworkVariableByte(0);

        [ServerRpc]
        public void SetTeamServerRpc(byte newTeamIndex)
        {
            // Make sure the newTeamIndex being received is valid
            if (newTeamIndex > 3) { return; }

            // Update the teamIndex NetworkVariable
            teamIndex.Value = newTeamIndex;
        }

        private void OnEnable()
        {
            // Start listening for the team index being updated
            teamIndex.OnValueChanged += OnTeamChanged;
        }

        private void OnDisable()
        {
            // Stop listening for the team index being updated
            teamIndex.OnValueChanged -= OnTeamChanged;
        }

        private void OnTeamChanged(byte oldTeamIndex, byte newTeamIndex)
        {
            // Only clients need to update the renderer
            if (!IsClient) { return; }

            // Update the colour of the player's mesh renderer
            teamColourRenderer.material.SetColor("_BaseColor", teamColours[newTeamIndex]);
        }
    }
}
