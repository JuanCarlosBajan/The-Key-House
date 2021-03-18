using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public  class MenuPrincipal : MonoBehaviour
{
    public GameObject Controles;
    public GameObject Preguntas;

    public static int nivel=1;

    // Start is called before the first frame update
    void Start()
    {
        if(Controles)
        {
            Controles.SetActive(false);
            Preguntas.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       

        
    }

    public void empezar()
    {
        SceneManager.LoadScene(nivel);
    }

    public void controles()
    {
        Controles.SetActive(!Controles.activeSelf);
    }

    public void Dudas()
    {
        Preguntas.SetActive(!Preguntas.activeSelf);
    }

    public void salir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }



}
