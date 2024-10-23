using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactionPrompt = "Подберите предмет"; // Текст по умолчанию

    public string InteractionPrompt => interactionPrompt;

    public void Interact()
    {
        // Визуально удаляем объект с сцены
        Destroy(gameObject);

        // Специфическая логика для предмета может быть расширена
        HandleItemInteraction();
    }

    protected virtual void HandleItemInteraction()
    {
        // Этот метод можно переопределять в наследуемых классах, если нужно
        Debug.Log("Взаимодействие с предметом");
    }
}
