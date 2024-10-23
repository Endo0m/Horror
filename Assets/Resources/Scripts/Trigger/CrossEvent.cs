using UnityEngine;

public class CrossEvent : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private float rotationSpeed = 2f; // �������� �������� ������
    private AudioSource _audioSource;
    private bool _hasTriggered = false;
    private bool _isRotating = false;

    private Quaternion _initialRotation;
    private Quaternion _targetRotation;

    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _initialRotation = transform.rotation;
        _targetRotation = _initialRotation * Quaternion.Euler(0f, 0f, 180f); // ������������� ���� �������� �� 180 ��������
    }

    // ����� ��� ������������ �������
    public void TriggerEvent()
    {
        if (_hasTriggered) return;

        // �������� ��������
        _isRotating = true;

        // ����������� ����
        PlaySound();

        _hasTriggered = true;
    }

    private void Update()
    {
        // ���� ������� ��������� � ��������� ��������
        if (_isRotating)
        {
            // ������ ������� ������
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, Time.deltaTime * rotationSpeed);

            // ���� ������� �������� (���� ������ � ��������)
            if (Quaternion.Angle(transform.rotation, _targetRotation) < 0.1f)
            {
                // ������������� ��������
                _isRotating = false;
                transform.rotation = _targetRotation; // ����������� ������ ��������� ���������� ����
            }
        }
    }

    private void PlaySound()
    {
        if (sound != null)
        {
            _audioSource.PlayOneShot(sound);
        }
    }
}
