using UnityEngine;

public class PaintingEvent : MonoBehaviour
{
    [SerializeField] private Material newMaterial;
    [SerializeField] private AudioClip sound;
    private AudioSource _audioSource;
    private bool _hasTriggered = false;

    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Метод для активации события
    public void TriggerEvent()
    {
        if (_hasTriggered) return;

        ChangeMaterial();
        PlaySound();

        _hasTriggered = true;
    }

    private void ChangeMaterial()
    {
        var renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = newMaterial;
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
