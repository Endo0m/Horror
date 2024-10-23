using System.Collections;
using UnityEngine;

public class GhostEvent : MonoBehaviour
{
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float speed = 2f;
    [SerializeField] private AudioClip moveSound;
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

        PlayMoveSound();
        StartCoroutine(MoveToTarget());

        _hasTriggered = true;
    }

    private void PlayMoveSound()
    {
        if (moveSound != null)
        {
            _audioSource.PlayOneShot(moveSound);
        }
    }

    private IEnumerator MoveToTarget()
    {
        while (Vector3.Distance(transform.position, targetPoint.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
            yield return null;
        }
    }
}
