using UnityEngine;

public class DoorController : MonoBehaviour, IInteractable
{
    [SerializeField] private float openAngle = 90f;
    [SerializeField] private float openSpeed = 2f;
    [SerializeField] private AudioClip openSound;
    [SerializeField] private AudioClip closeSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] public bool requiresKey = false; // ��������� �� ���� ��� �����
    [SerializeField] public bool isFinalDoor = false; // �������� �� ����� ���������

    protected bool isOpen = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    public string InteractionPrompt
    {
        get
        {
            if (requiresKey && !InventoryManager.Instance.HasKey)
            {
                return "����� ����!";
            }
            return isOpen ? "������� �����" : "������� �����";
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
        // ���� ��������� ���� � ����� ���, ����� �� �����������
        if (requiresKey && !InventoryManager.Instance.HasKey)
        {
            Debug.Log("����� ���� ��� �������� �����.");
            return;
        }

        // ��������/�������� �����
        isOpen = !isOpen;
        PlaySound(isOpen ? openSound : closeSound);

        // ���� ����� ���������, ���������� �������������� ������ (����� �������������� � FinalDoorController)
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

    // ����������� ����� ��� ��������� �������� ��������� �����, ���� ��� �������� ��� "Final Door"
    protected virtual void OnFinalDoorOpened()
    {
        // ���������������� � FinalDoorController
    }
}
