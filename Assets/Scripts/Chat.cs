using System;
using MLAPI;
using MLAPI.NetworkVariable.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : NetworkBehaviour
{
    public NetworkList<string> ChatMessages = new NetworkList<string>(new MLAPI.NetworkVariable.NetworkVariableSettings()
    {
        ReadPermission = MLAPI.NetworkVariable.NetworkVariablePermission.Everyone,
        WritePermission = MLAPI.NetworkVariable.NetworkVariablePermission.Everyone,
        SendTickrate = 5
    }, new List<string>());

    public bool chatOn;
    private string textField = "";
    // private Vector2 vScrollPos;

    private void OnGUI ()
    {
        if (IsLocalPlayer)
        {
            textField = GUILayout.TextField(textField, GUILayout.Width(200));
            if (GUILayout.Button("Send",GUILayout.Width(200)) && !string.IsNullOrWhiteSpace(textField))
            {
                ChatMessages.Add(textField);
                chatOn = true;
                textField = "";
            }

            // vScrollPos = GUI.BeginScrollView(new Rect(0, 100, 200, 100), vScrollPos, new Rect(0, 0, 500, 700));
            // for (int i = ChatMessages.Count - 1; i >= 0; i--)
            // {
            //     GUILayout.Label(ChatMessages[i]);
            // }
            // // for (int i = 0; i < ChatMessages.Count; i++)
            // // {
            // //     GUILayout.Label(ChatMessages[i]);
            // // }
            // GUI.EndScrollView();
        }
    }
}
