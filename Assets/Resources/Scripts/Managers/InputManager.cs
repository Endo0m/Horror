using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float interactDistance = 3f; // Дистанция взаимодействия
    [SerializeField] private LayerMask interactableLayer; // Слой для всех интерактивных объектов
    [SerializeField] private TMP_Text interactionText; // Текст для отображения взаимодействия

    private IInteractable currentInteractable;

    private void Update()
    {
        HandleInteraction();
    }

    private void HandleInteraction()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactableLayer))
        {
            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                // Показываем подсказку о взаимодействии
                interactionText.text = interactable.InteractionPrompt;
                interactionText.gameObject.SetActive(true);
                currentInteractable = interactable;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentInteractable.Interact();
                }
            }
        }
        else
        {
            interactionText.gameObject.SetActive(false);
            currentInteractable = null;
        }
    }
}
