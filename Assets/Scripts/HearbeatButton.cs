using UnityEngine;
using UnityEngine.UI;

public class HeartbeatButton : MonoBehaviour
{
    // Refer�ncia ao componente AudioSource
    private AudioSource audioSource;

    void Start()
    {
        // Obt�m o componente AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    // M�todo para reproduzir o som
    public void PlayHeartbeat()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("AudioSource ou AudioClip n�o est� configurado.");
        }
    }
}
