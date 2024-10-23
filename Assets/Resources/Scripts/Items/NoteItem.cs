using UnityEngine;

public class NoteItem : InteractableItem
{
    [SerializeField] private GameObject notePanel;

    protected override void HandleItemInteraction()
    {
        // Открытие UI записки
        if (notePanel != null)
        {
            notePanel.SetActive(true);
        }
        Debug.Log("Записка прочитана");
    }
}
