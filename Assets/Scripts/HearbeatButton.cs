using UnityEngine;
using UnityEngine.UI;

public class HeartbeatButton : MonoBehaviour
{
    // Referência ao componente AudioSource
    private AudioSource audioSource;

    void Start()
    {
        // Obtém o componente AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    // Método para reproduzir o som
    public void PlayHeartbeat()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource ou AudioClip não está configurado.");
        }
    }
}
