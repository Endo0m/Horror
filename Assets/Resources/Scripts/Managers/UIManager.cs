using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{ // ������ ��� ������� ������
    public void StartLevel()
    {
        SceneManager.LoadScene("Game"); 
    }
    // ������ ��� ����������� ������
    public void RestartLevel()
    {
        Time.timeScale = 1f; // ���������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // ������������� ������� �����
    }

    // ������ ��� ������ �� ����
    public void ExitGame()
    {
        Application.Quit();
    }
}
