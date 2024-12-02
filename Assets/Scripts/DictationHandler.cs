using UnityEngine;
using UnityEngine.UI;
using Meta.WitAi;
using Meta.WitAi.Dictation;
using Oculus.Voice;
using Oculus.Voice.Dictation;
using TMPro;

public class DictationHandler : MonoBehaviour
{
    [Header("Wit Configuration")]
    [SerializeField] private AppDictationExperience appVoiceExperience;
    private bool active;
    public TextMeshProUGUI transcriptDebug;
    public TextMeshProUGUI transcriptFull;
    private string lastTranscription;
    private int currentPage;
    private int maxPage;
    public TextMeshProUGUI pageString;
    private int transcriptionCount;

    public void Start()
    {
        if (appVoiceExperience != null)
        {
            appVoiceExperience.Deactivate(); // Garante que est� desativado ao iniciar
        }
        lastTranscription = string.Empty;
        transcriptDebug.text = string.Empty;
        transcriptFull.text = string.Empty;
        active = false;
        currentPage = 1;
        transcriptionCount = 0;
    }

    public void OnDisable()
    {
        Microphone.End(null);
        StopTranscription();
    }

    public void Update()
    {
        maxPage = transcriptFull.textInfo.pageCount;
        pageString.text = currentPage.ToString() + "/" + maxPage.ToString();
    }

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
            if (lastTranscription != string.Empty)
            {
                transcriptFull.text += lastTranscription + "\n\n";
                lastTranscription = string.Empty;
            }
            transcriptionCount++;
            transcriptFull.text += "GRAVA��O " + transcriptionCount.ToString() + "\n\n";
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
        transcriptDebug.text = transcription;
        if (!transcription.StartsWith(lastTranscription))
        {
            transcriptFull.text += lastTranscription + "\n";
        }
        lastTranscription = transcription;
    }

    public void NextPage()
    {
        if (transcriptFull.pageToDisplay < maxPage)
        {
            transcriptFull.pageToDisplay += 1;
            currentPage = transcriptFull.pageToDisplay;
        }
    }

    public void PreviousPage()
    {
        if (transcriptFull.pageToDisplay > 1)
        {
            transcriptFull.pageToDisplay -= 1;
            currentPage = transcriptFull.pageToDisplay;
        }
    }

    public void FirstPage()
    {
        transcriptFull.pageToDisplay = 1;
        currentPage = transcriptFull.pageToDisplay;
    }

    public void LastPage()
    {
        transcriptFull.pageToDisplay = maxPage;
        currentPage = transcriptFull.pageToDisplay;
    }
}
