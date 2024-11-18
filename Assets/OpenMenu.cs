using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    // Referência pública ao menu que será ativado/desativado
    public GameObject menu;

    // Variável para checar se o jogador está na área de interação
    private bool jogadorNaArea = false;

    void Start()
    {
        // Certifica-se de que o menu está desativado no início
        if (menu != null)
        {
            menu.SetActive(false);
        }
    }

    void Update()
    {
        // Verifica se o jogador está na área e pressionou "E"
        if (jogadorNaArea && Input.GetKeyDown(KeyCode.E))
        {
            // Ativar o menu
            menu.SetActive(true);
        }
    }

    // Detecta quando o jogador entra na área de interação
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que entrou é o jogador (usa a tag "Player" para identificar)
        if (other.CompareTag("Player"))
        {
            jogadorNaArea = true;
        }
    }

    // Detecta quando o jogador sai da área de interação
    private void OnTriggerExit(Collider other)
    {
        // Verifica se o objeto que saiu é o jogador
        if (other.CompareTag("Player"))
        {
            jogadorNaArea = false;
        }
    }
}
