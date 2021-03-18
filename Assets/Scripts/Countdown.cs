using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{

    public GameObject panel;
    float transparency = 0;
    public Image potion;
    public Text Muerte;
    // Start is called before the first frame update
    void Start()
    
    {
        Muerte.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        panel.GetComponent<Image>().color = new Color(0, 255, 0, transparency + 1 * Time.deltaTime * 0.001f);
        transparency += Time.deltaTime * 0.005f;
        potion.fillAmount += Time.deltaTime * 0.01f;

        if(transparency>=0.495)
            Muerte.enabled = true;
        if (transparency >= 0.50)
        {

                SceneManager.LoadScene(1);
        }
    }


}
