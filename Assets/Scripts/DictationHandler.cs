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

    // M�todo p�blico para iniciar a transcri��o, chamado pelo bot�o de in�cio
    public void StartTranscription()
    {
        if (appVoiceExperience == null)
        {
            Debug.LogError("AppVoiceExperience n�o foi atribu�do no Inspector!");
            return;
        }

        if (!active)
        {
            active = true;
            appVoiceExperience.Activate();
            appVoiceExperience.DictationEvents.OnPartialTranscription.AddListener(OnPartialTranscription);
            Debug.Log("Transcri��o iniciada.");
        }
    }

    // M�todo p�blico para parar a transcri��o, chamado pelo bot�o de parada
    public void StopTranscription()
    {
        if (active)
        {
            active = false;
            appVoiceExperience.Deactivate();
            appVoiceExperience.DictationEvents.OnPartialTranscription.RemoveListener(OnPartialTranscription);
            Debug.Log("Transcri��o interrompida.");
        }
    }

    private void OnPartialTranscription(string transcription)
    {
        Debug.Log(transcription);
        transcript.text = transcription;
    }
}
