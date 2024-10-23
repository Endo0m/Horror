using UnityEngine;

public class NoteItem : InteractableItem
{
    [SerializeField] private GameObject notePanel;

    protected override void HandleItemInteraction()
    {
        // �������� UI �������
        if (notePanel != null)
        {
            notePanel.SetActive(true);
        }
        Debug.Log("������� ���������");
    }
}
