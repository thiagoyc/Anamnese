using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    // Refer�ncia p�blica ao menu que ser� ativado/desativado
    public GameObject menu;

    // Vari�vel para checar se o jogador est� na �rea de intera��o
    private bool jogadorNaArea = false;

    void Start()
    {
        // Certifica-se de que o menu est� desativado no in�cio
        if (menu != null)
        {
            menu.SetActive(false);
        }
    }

    void Update()
    {
        // Verifica se o jogador est� na �rea e pressionou "E"
        if (jogadorNaArea && Input.GetKeyDown(KeyCode.E))
        {
            // Ativar o menu
            menu.SetActive(true);
        }
    }

    // Detecta quando o jogador entra na �rea de intera��o
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou � o jogador (usa a tag "Player" para identificar)
        if (other.CompareTag("Player"))
        {
            jogadorNaArea = true;
        }
    }

    // Detecta quando o jogador sai da �rea de intera��o
    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu � o jogador
        if (other.CompareTag("Player"))
        {
            jogadorNaArea = false;
        }
    }
}
