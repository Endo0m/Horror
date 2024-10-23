using UnityEngine;

public class BookEvent : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    private AudioSource _audioSource;
    private Rigidbody _rigidbody;
    private bool _hasTriggered = false;

    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Метод для активации события
    public void TriggerEvent()
    {
        if (_hasTriggered) return;

        ApplyForceToBook();
        PlaySound();

        _hasTriggered = true;
    }

    private void ApplyForceToBook()
    {
        _rigidbody.AddForce(Vector3.back * 10f, ForceMode.Impulse);
    }

    private void PlaySound()
    {
        if (sound != null)
        {
            _audioSource.PlayOneShot(sound);
        }
    }
}

