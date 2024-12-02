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
            appVoiceExperience.Deactivate(); // Garante que está desativado ao iniciar
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
            if (lastTranscription != string.Empty)
            {
                transcriptFull.text += lastTranscription + "\n\n";
                lastTranscription = string.Empty;
            }
            transcriptionCount++;
            transcriptFull.text += "GRAVAÇÃO " + transcriptionCount.ToString() + "\n\n";
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
