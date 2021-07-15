using System;
using System.Collections;
using System.Collections.Generic;
using MLAPI;
// using MLAPI.Transports.PhotonRealtime;
// using Photon.Realtime;
using UnityEngine;

public class InteractionNPC : NetworkBehaviour
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
