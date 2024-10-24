using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    [SerializeField] private AudioSource footstepAudioSource; // ������������� ��� ��������������� �����
    [SerializeField] private AudioClip[] footstepSounds; // ������ ������ �����
    [SerializeField] private float footstepDelay = 0.5f; // �������� ����� ������

    private float stepTimer = 0f; // ������ ��� ������� ������� ����� ������

    private void Update()
    {
        HandleFootsteps();
    }

    private void HandleFootsteps()
    {
        // ���������, ��� ����� �� ����������
        if (Time.timeScale == 0f)
        {
            return; // ��������� ����������, ���� ����� �����������
        }

        // ���������, ������ �� ������� ��������
        if (IsMoving())
        {
            stepTimer -= Time.deltaTime;

            // ���� ������ ����������, ������������� ���
            if (stepTimer <= 0f)
            {
                PlayFootstepSound();
                stepTimer = footstepDelay; // ���������� ������ ��� ���������� ����
            }
        }
        else
        {
            // ���� ����� �� ���������, ���������� ������
            stepTimer = 0f;
        }
    }

    private bool IsMoving()
    {
        // ��������� ���� � ���������� (W, A, S, D ��� �������)
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
               Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
               Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ||
               Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
    }

    private void PlayFootstepSound()
    {
        if (footstepSounds.Length > 0 && footstepAudioSource != null)
        {
            // �������� ��������� ���� �� ������� �����
            AudioClip clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            footstepAudioSource.PlayOneShot(clip);
        }
    }
}
