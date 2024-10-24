using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    [SerializeField] private AudioSource footstepAudioSource; // Аудиоисточник для воспроизведения шагов
    [SerializeField] private AudioClip[] footstepSounds; // Массив звуков шагов
    [SerializeField] private float footstepDelay = 0.5f; // Задержка между шагами

    private float stepTimer = 0f; // Таймер для отсчета времени между шагами

    private void Update()
    {
        HandleFootsteps();
    }

    private void HandleFootsteps()
    {
        // Проверяем, что время не заморожено
        if (Time.timeScale == 0f)
        {
            return; // Прерываем выполнение, если время остановлено
        }

        // Проверяем, нажаты ли клавиши движения
        if (IsMoving())
        {
            stepTimer -= Time.deltaTime;

            // Если таймер завершился, воспроизводим шаг
            if (stepTimer <= 0f)
            {
                PlayFootstepSound();
                stepTimer = footstepDelay; // Сбрасываем таймер для следующего шага
            }
        }
        else
        {
            // Если игрок не двигается, сбрасываем таймер
            stepTimer = 0f;
        }
    }

    private bool IsMoving()
    {
        // Проверяем ввод с клавиатуры (W, A, S, D или стрелки)
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) ||
               Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
               Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ||
               Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
    }

    private void PlayFootstepSound()
    {
        if (footstepSounds.Length > 0 && footstepAudioSource != null)
        {
            // Выбираем случайный звук из массива шагов
            AudioClip clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            footstepAudioSource.PlayOneShot(clip);
        }
    }
}
