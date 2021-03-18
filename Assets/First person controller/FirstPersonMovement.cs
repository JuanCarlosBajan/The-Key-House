using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    Vector2 velocity;
    public GameObject PauseMenu;
    public GameObject LoadingScreen;
    public Image fadePanel;
    
    

    void FixedUpdate()
    {
        if (PauseMenu.activeSelf == false)
        {
            velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(velocity.x, 0, velocity.y);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Nivel2"))
        {
            Darken();
            StartCoroutine(LoadSceneAsync("Nivel2"));
        }

        if (other.gameObject.CompareTag("Nivel3"))
        {
            Darken();
            StartCoroutine(LoadSceneAsync("FinalScene"));
        }

        if (other.gameObject.CompareTag("Obstaculo"))
        {
            transform.position = new Vector3(133f, 49f, 241f);
        }



    }

    


    IEnumerator LoadSceneAsync(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        LoadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            //girar moneda
            yield return null;
        }

        yield return new WaitForSeconds(10.0f);
    }

    public void Darken(){
        StartCoroutine(FadeToBlack(1.0f));
    }

    IEnumerator FadeToBlack(float _time)
    {
        
        fadePanel.color = new Color(0, 0, 0, 0);

        for (float t = 0.0f; t < _time; t += Time.deltaTime)
        {
            Color newColor = fadePanel.color;
            newColor.a = t / _time;
            fadePanel.color = newColor;
            yield return null;
        }
       
    }

}
