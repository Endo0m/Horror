using UnityEngine;

public class CrossEvent : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private float rotationSpeed = 2f; // Скорость поворота креста
    private AudioSource _audioSource;
    private bool _hasTriggered = false;
    private bool _isRotating = false;

    private Quaternion _initialRotation;
    private Quaternion _targetRotation;

    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _initialRotation = transform.rotation;
        _targetRotation = _initialRotation * Quaternion.Euler(0f, 0f, 180f); // Устанавливаем цель поворота на 180 градусов
    }

    // Метод для срабатывания события
    public void TriggerEvent()
    {
        if (_hasTriggered) return;

        // Начинаем вращение
        _isRotating = true;

        // Проигрываем звук
        PlaySound();

        _hasTriggered = true;
    }

    private void Update()
    {
        // Если событие сработало и требуется вращение
        if (_isRotating)
        {
            // Плавно вращаем объект
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, Time.deltaTime * rotationSpeed);

            // Если поворот завершён (угол близок к целевому)
            if (Quaternion.Angle(transform.rotation, _targetRotation) < 0.1f)
            {
                // Останавливаем вращение
                _isRotating = false;
                transform.rotation = _targetRotation; // Гарантируем точную установку финального угла
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
