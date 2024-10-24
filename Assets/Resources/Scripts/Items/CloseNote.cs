using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseNote : MonoBehaviour
{
    [SerializeField] private GameObject notePanel;

    private void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Закрываем панель при нажатии Space
        if (Input.GetKeyDown(KeyCode.Space) && notePanel != null && notePanel.activeSelf)
        {
            Time.timeScale = 1f;

            notePanel.SetActive(false);
        }
    }
}
