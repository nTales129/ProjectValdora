using UnityEngine;
using UnityEngine.InputSystem;

public class ChestInteractable : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private GameObject interactPrompt; // o objeto "InteractPrompt"

    private bool playerInRange;

    void Start()
    {
        if (interactPrompt != null)
        {
            interactPrompt.SetActive(false); // começa escondido
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactPrompt != null) interactPrompt.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactPrompt != null) interactPrompt.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("Interagiu com o baú!");
        }
    }
}