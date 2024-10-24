using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{ // Кнопка для запуска уровня
    public void StartLevel()
    {
        SceneManager.LoadScene("Game"); 
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
