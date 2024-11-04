using UnityEngine;
using UnityEngine.UI;
using Meta.WitAi;
using Meta.WitAi.Dictation;
using UnityEngine.Android;
using Oculus.Voice;
using Oculus.Voice.Dictation;

public class DictationHandler : MonoBehaviour
{
    [Header("Wit Configuration")]
    [SerializeField] private AppDictationExperience appVoiceExperience;
    public bool active;
    void Start()
    {
        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!active)
            {
                StartTranscription();
            }
            else
            {
                StopTranscription();
            }
        }
    }

    private void OnPartialTranscription(string transcription)
    {
        Debug.Log(transcription);
        // Use a transcrição aqui, como exibir na tela ou processar o texto
    }

    private void StartTranscription()
    {
        active = true;
        appVoiceExperience.Activate();
        appVoiceExperience.DictationEvents.OnPartialTranscription.AddListener(OnPartialTranscription);
    }

    private void StopTranscription()
    {
        active = false;
        appVoiceExperience.Deactivate();
        appVoiceExperience.DictationEvents.OnPartialTranscription.RemoveListener(OnPartialTranscription);
        Debug.Log("Transcrição interrompida pelo botão.");
    }
}