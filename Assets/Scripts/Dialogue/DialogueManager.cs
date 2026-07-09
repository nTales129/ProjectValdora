using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [Header("Referências de UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI npcNameText;
    [SerializeField] private TextMeshProUGUI dialogueText;

    private string[] currentLines;
    private int currentLineIndex;
    private bool isDialogueActive;

    void Awake()
    {
        // Garante que só existe um DialogueManager na cena
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Update()
    {
        if (!isDialogueActive) return;

        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            AdvanceDialogue();
        }
    }

    public void StartDialogue(string npcName, string[] lines)
    {
        isDialogueActive = true;
        currentLines = lines;
        currentLineIndex = 0;

        dialoguePanel.SetActive(true);
        npcNameText.text = npcName;
        dialogueText.text = currentLines[currentLineIndex];
    }

    private void AdvanceDialogue()
    {
        currentLineIndex++;

        if (currentLineIndex >= currentLines.Length)
        {
            EndDialogue();
            return;
        }

        dialogueText.text = currentLines[currentLineIndex];
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }
}