using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactionPrompt = "��������� �������"; // ����� �� ���������

    public string InteractionPrompt => interactionPrompt;

    public void Interact()
    {
        // ��������� ������� ������ � �����
        Destroy(gameObject);

        // ������������� ������ ��� �������� ����� ���� ���������
        HandleItemInteraction();
    }

    protected virtual void HandleItemInteraction()
    {
        // ���� ����� ����� �������������� � ����������� �������, ���� �����
        Debug.Log("�������������� � ���������");
    }
}
