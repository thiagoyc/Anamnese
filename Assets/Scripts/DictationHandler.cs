using UnityEngine;
using UnityEngine.UI;
using Meta.WitAi;
using Meta.WitAi.Dictation;
using Oculus.Voice;
using Oculus.Voice.Dictation;
using TMPro;
using static System.Net.Mime.MediaTypeNames;

public class DictationHandler : MonoBehaviour
{
    [Header("Wit Configuration")]
    [SerializeField] private AppDictationExperience appVoiceExperience;
    public bool active;
    public TextMeshProUGUI transcript;

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
        transcript.text = transcription;
    }
}
