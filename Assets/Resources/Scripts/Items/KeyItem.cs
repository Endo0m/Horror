using UnityEngine;

public class KeyItem : InteractableItem
{
    protected override void HandleItemInteraction()
    {
        // ������ ��������� �����
        InventoryManager.Instance.AddKey();
        Debug.Log("���� ��������");
    }
}
