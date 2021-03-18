using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject PauseMenu;
    public bool Potions;
    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    //Función de Pausa
    public void TogglePause()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        Time.timeScale = PauseMenu.activeSelf ? 0.0f : 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }
    


}
