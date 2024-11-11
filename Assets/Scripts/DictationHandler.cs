using UnityEngine;
using UnityEngine.UI;
using Meta.WitAi;
using Meta.WitAi.Dictation;
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

    // Método público para iniciar a transcrição, chamado pelo botão de início
    public void StartTranscription()
    {
        if (appVoiceExperience == null)
        {
            Debug.LogError("AppVoiceExperience não foi atribuído no Inspector!");
            return;
        }

        if (!active)
        {
            active = true;
            appVoiceExperience.Activate();
            appVoiceExperience.DictationEvents.OnPartialTranscription.AddListener(OnPartialTranscription);
            Debug.Log("Transcrição iniciada.");
        }
    }

    // Método público para parar a transcrição, chamado pelo botão de parada
    public void StopTranscription()
    {
        if (active)
        {
            active = false;
            appVoiceExperience.Deactivate();
            appVoiceExperience.DictationEvents.OnPartialTranscription.RemoveListener(OnPartialTranscription);
            Debug.Log("Transcrição interrompida.");
        }
    }

    private void OnPartialTranscription(string transcription)
    {
        Debug.Log(transcription);
        // Use a transcrição aqui, como exibir na tela ou processar o texto
    }
}
