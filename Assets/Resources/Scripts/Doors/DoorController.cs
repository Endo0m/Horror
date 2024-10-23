using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float openSpeed = 2f;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] public bool requiresKey = false; // Требуется ли ключ для двери
    [SerializeField] public bool isFinalDoor = false; // Является ли дверь финальной

    protected bool isOpen = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    public string InteractionPrompt
    {
        get
        {
            if (requiresKey && !InventoryManager.Instance.HasKey)
            {
                return "Нужен ключ!";
            }
            return isOpen ? "Закрыть дверь" : "Открыть дверь";
        }
    }

    protected virtual void Start()
    {
        initialRotation = transform.rotation;
        targetRotation = initialRotation * Quaternion.Euler(0, openAngle, 0);

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public virtual void Interact()
    {
        // Если требуется ключ и ключа нет, дверь не открывается
        if (requiresKey && !InventoryManager.Instance.HasKey)
        {
            Debug.Log("Нужен ключ для открытия двери.");
            return;
        }

        // Открытие/закрытие двери
        isOpen = !isOpen;
        PlaySound(isOpen ? openSound : closeSound);

        // Если дверь финальная, производим дополнительную логику (будет обрабатываться в FinalDoorController)
        if (isFinalDoor && isOpen)
        {
            OnFinalDoorOpened();
        }
    }

    protected virtual void Update()
    {
        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, Time.deltaTime * openSpeed);
        }
    }

    protected void PlaySound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    // Виртуальный метод для обработки открытия финальной двери, если она отмечена как "Final Door"
    protected virtual void OnFinalDoorOpened()
    {
        // Переопределяется в FinalDoorController
    }
}
