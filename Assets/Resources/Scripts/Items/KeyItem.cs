using UnityEngine;

public class KeyItem : InteractableItem
{
    protected override void HandleItemInteraction()
    {
        // Логика получения ключа
        InventoryManager.Instance.AddKey();
        Debug.Log("Ключ подобран");
    }
}
