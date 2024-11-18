using Meta.WitAi.TTS.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandleInput : MonoBehaviour
{
    public TMP_InputField inputField;

    [SerializeField]
    public TTSSpeaker speaker;

    public void SendTextToVR()
    {

        // Atualiza o texto no VR
        Debug.Log(inputField.text);

        speaker.Speak(inputField.text);

        // Limpa o campo de texto
        inputField.text = "";

        
    }
}
