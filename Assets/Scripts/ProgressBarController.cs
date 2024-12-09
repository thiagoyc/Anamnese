using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progressBar; // Barra de progresso
    public float progressSpeed = 0.5f; // Velocidade de carregamento da barra
    public GameObject resultObject; // Objeto a ser exibido ao completar
    public AudioSource audioSource; // Som a ser tocado durante o progresso

    private bool isProgressRunning = false; // Controle do progresso
    private bool hasProcessed = false; // Evita múltiplos processamentos

    void Start()
    {
        // Inicializa o estado
        progressBar.value = 0f;
        progressBar.gameObject.SetActive(true); // Mostra a barra inicialmente
        if (resultObject != null)
        {
            resultObject.SetActive(false); // Esconde o resultado inicialmente
        }
    }

    void Update()
    {
        if (isProgressRunning)
        {
            // Incrementa o progresso
            progressBar.value += progressSpeed * Time.deltaTime;

            // Quando o progresso chega ao máximo
            if (progressBar.value >= 1f && !hasProcessed)
            {
                hasProcessed = true;
                CompleteProgress();
            }
        }
    }

    public void StartProgress()
    {
        isProgressRunning = true; // Inicia o progresso
        progressBar.value = 0f; // Reinicia a barra
        hasProcessed = false; // Permite novo processamento

        // Toca o som associado
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        // Certifica-se de que os elementos estão no estado inicial
        progressBar.gameObject.SetActive(true);
        if (resultObject != null)
        {
            resultObject.SetActive(false); // Esconde o resultado
        }
    }

    private void CompleteProgress()
    {
        isProgressRunning = false; // Para o progresso

        // Para o som
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Troca a barra pelo resultado
        progressBar.gameObject.SetActive(false); // Esconde a barra
        if (resultObject != null)
        {
            resultObject.SetActive(true); // Mostra o resultado
        }

        Debug.Log("Exame completo!");
    }
}
