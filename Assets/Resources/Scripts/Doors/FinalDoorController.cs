using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoorController : DoorController
{
    [SerializeField] private GameObject winUIPanel; // Панель победы для отображения
    [SerializeField] private AudioClip winSound; // Звук победы

    // Переопределение метода обработки финальной двери
    protected override void OnFinalDoorOpened()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // Останавливаем время
        Time.timeScale = 0f;

        // Проигрываем победный звук
        PlaySound(winSound);

        // Показываем UI победы
        if (winUIPanel != null)
        {
            winUIPanel.SetActive(true);
        }
    }

    // Кнопка для перезапуска уровня
    public void RestartLevel()
    {
        Time.timeScale = 1f; // Возвращаем время
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Перезагружаем текущую сцену
    }

    // Кнопка для выхода из игры
    public void ExitGame()
    {
        Application.Quit();
    }
}
