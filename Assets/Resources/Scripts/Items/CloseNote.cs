using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseNote : MonoBehaviour
{
    [SerializeField] private GameObject notePanel;


    // Update is called once per frame
    void Update()
    {
        // Закрываем панель при нажатии Space
        if (Input.GetKeyDown(KeyCode.Space) && notePanel != null && notePanel.activeSelf)
        {
            notePanel.SetActive(false);
        }
    }
}
