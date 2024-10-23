using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoorController : DoorController
{
    [SerializeField] private GameObject winUIPanel; // ������ ������ ��� �����������
    [SerializeField] private AudioClip winSound; // ���� ������

    // ��������������� ������ ��������� ��������� �����
    protected override void OnFinalDoorOpened()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // ������������� �����
        Time.timeScale = 0f;

        // ����������� �������� ����
        PlaySound(winSound);

        // ���������� UI ������
        if (winUIPanel != null)
        {
            winUIPanel.SetActive(true);
        }
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
