using MLAPI;
using UnityEngine; // using MLAPI.Transports.PhotonRealtime;
// using Photon.Realtime;

namespace _1MDemo.Scripts
{
    public class InteractionNpc : NetworkBehaviour
    {
        private GameObject m_NPC;
        void Start()
        {
            m_NPC = GameObject.Find("Souta");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("NPC") && IsLocalPlayer)
            {
                m_NPC.transform.Find("ExclamationMark").gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("NPC") && IsLocalPlayer)
            {
                m_NPC.transform.Find("ExclamationMark").gameObject.SetActive(false);
            }
        }
    }
}
