// using System.Collections;
// using System.Collections.Generic;
// using _1MDemo.Scripts;
// using MLAPI;
// using MLAPI.Messaging;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;
//
// public class SpeechBubble : NetworkBehaviour
// {
//     private Transform cameraAngle;
//     private Chat chatInfo;
//     public TextMeshPro speech;
//     private GameObject speechBubble;
//
//     void Start()
//     {
//         cameraAngle = FindObjectOfType<Camera>().transform;
//         // chatInfo = GameObject.Find("Player").GetComponent<Chat>();
//         chatInfo = transform.parent.gameObject.GetComponent<Chat>();
//         // speech = GameObject.Find("Speech").GetComponent<TextMeshPro>();
//         speechBubble = transform.Find("SpeechBubble").gameObject;
//     }
//
//     void CloseSpeechBubble()
//     {
//         speechBubble.SetActive(false);
//     }
//
//
//     void Update()
//     {
//         // speechBubble.transform.rotation = cameraAngle.rotation;
//         speechBubble.transform.LookAt(cameraAngle);
//         if (IsLocalPlayer && chatInfo.chatOn)
//         {
//             speechBubble.SetActive(true);
//             speech.text = chatInfo.ChatMessages[chatInfo.ChatMessages.Count - 1];
//             chatInfo.chatOn = false;
//             Invoke("CloseSpeechBubble",10);
//         }
//     }
// }
