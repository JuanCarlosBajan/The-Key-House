using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    Transform character;
    Vector2 currentMouseLook;
    Vector2 appliedMouseDelta;
    public float sensitivity = 1;
    public float smoothing = 2;
    public GameObject PauseMenu;
    public bool potionA = false;
    public bool potionB = false;
    public bool potionC = false;
    public int boxes = 0;
    public GameObject key;
    public bool keyFinal = false;
    public GameObject partcls;
    Rigidbody doorRB;
    public GameObject jumpscare;
    GameObject bottleMana;
    GameObject bottleHealth;
    GameObject bottleEndurance;
    public GameObject[] spawns;

    public Image rojo;
    public Image verde;
    public Image azul;



    void Reset()
    {
        character = GetComponentInParent<FirstPersonMovement>().transform;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if(rojo && azul && verde)
        {
            if (potionA)
                azul.enabled = true;
            else
                azul.enabled = false;

            if (potionB)
                rojo.enabled = true;
            else
                rojo.enabled = false;
            if (potionC)
                verde.enabled = true;
            else
                verde.enabled = false;



        }

        if (PauseMenu.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // Get smooth mouse look.
            Vector2 smoothMouseDelta = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), Vector2.one * sensitivity * smoothing);
            appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, smoothMouseDelta, 1 / smoothing);
            currentMouseLook += appliedMouseDelta;
            currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -90, 90);

            // Rotate camera and controller.
            transform.localRotation = Quaternion.AngleAxis(-currentMouseLook.y, Vector3.right);
            character.localRotation = Quaternion.AngleAxis(currentMouseLook.x, Vector3.up);

            Ray myray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            Debug.DrawRay(myray.origin, myray.direction * 5, Color.red);
            RaycastHit hitinfo;

            if (Physics.Raycast(myray, out hitinfo, 5f) && Input.GetMouseButtonDown(0) && hitinfo.collider.gameObject.name == "Bottle_Mana")
            {
                bottleMana = hitinfo.collider.gameObject;
                hitinfo.collider.gameObject.SetActive(false);
                potionA = true;
            }

            if (Physics.Raycast(myray, out hitinfo, 5f) && Input.GetMouseButtonDown(0) && hitinfo.collider.gameObject.CompareTag("Box1") && potionA == true) {

                Animator anim = hitinfo.collider.gameObject.GetComponent<Animator>();

                hitinfo.collider.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                BoxCollider bc = hitinfo.collider.gameObject.GetComponent<BoxCollider>();
                bc.enabled = false;
                GameObject obj = hitinfo.collider.gameObject.transform.GetChild(2).gameObject;
                obj.SetActive(true);
                anim.SetBool("Interractuar", true);
                anim.SetBool("PotionR", true);
                boxes++;
                potionA = false;

                if (boxes == 3)
                {

                    StartCoroutine(ActivateKey());

                }


            }
            if (Physics.Raycast(myray, out hitinfo, 5f) && Input.GetMouseButtonDown(0) && hitinfo.collider.gameObject.name == "Bottle_Health")
            {
                bottleHealth = hitinfo.collider.gameObject;
                hitinfo.collider.gameObject.SetActive(false);
                potionB = true;
            }

            if (Physics.Raycast(myray, out hitinfo, 5f) && Input.GetMouseButtonDown(0) && hitinfo.collider.gameObject.CompareTag("Box2") && potionB == true)
            {

                Animator anim = hitinfo.collider.gameObject.GetComponent<Animator>();
                BoxCollider bc = hitinfo.collider.gameObject.GetComponent<BoxCollider>();
                bc.enabled = false;
                hitinfo.collider.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                GameObject obj = hitinfo.collider.gameObject.transform.GetChild(2).gameObject;
                obj.SetActive(true);
                anim.SetBool("Interractuar", true);
                anim.SetBool("PotionR", true);
                boxes++;
                potionB = false;

                if (boxes == 3)
                {

                    StartCoroutine(ActivateKey());

                }

            }
            if (Physics.Raycast(myray, out hitinfo, 5f) && Input.GetMouseButtonDown(0) && hitinfo.collider.gameObject.name == "Bottle_Endurance")
            {
                bottleEndurance = hitinfo.collider.gameObject;
                hitinfo.collider.gameObject.SetActive(false);
                potionC = true;
            }

            if (Physics.Raycast(myray, out hitinfo, 5f) && Input.GetMouseButtonDown(0) && hitinfo.collider.gameObject.CompareTag("Box3") && potionC == true)
            {

                Animator anim = hitinfo.collider.gameObject.GetComponent<Animator>();
                BoxCollider bc = hitinfo.collider.gameObject.GetComponent<BoxCollider>();
                bc.enabled = false;
                hitinfo.collider.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                GameObject obj = hitinfo.collider.gameObject.transform.GetChild(2).gameObject;
                obj.SetActive(true);
                anim.SetBool("Interractuar", true);
                anim.SetBool("PotionR", true);
                boxes++;
                potionC = false;

                if (boxes == 3)
                {

                    StartCoroutine(ActivateKey());
                }

            }

            if (Physics.Raycast(myray, out hitinfo, 5f) && Input.GetMouseButtonDown(0) && hitinfo.collider.gameObject.CompareTag("FinalKey"))
            {

                hitinfo.collider.gameObject.SetActive(false);
                keyFinal = true;


            }

            if (Physics.Raycast(myray, out hitinfo, 5f) && Input.GetMouseButton(0) && hitinfo.collider.gameObject.CompareTag("DoorFinal") && keyFinal)
            {
               

                doorRB = hitinfo.collider.gameObject.GetComponentInParent<Rigidbody>();

                bool open = true;
                if (doorRB.transform.eulerAngles.y <= 275 && open)
                {
                    doorRB.transform.Rotate(0, 30 * Time.deltaTime, 0);
                }
                else
                {
                    open = false;
                }

                if (doorRB.transform.eulerAngles.y > 190) {


                    AudioSource fff = hitinfo.collider.gameObject.GetComponent<AudioSource>();
                    fff.Play();
                    jumpscare.gameObject.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;                    
                    SceneManager.LoadScene(4);
                    loadscene("extra");

                }
            }

        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        for (int x = 0; x<spawns.Length;x++) {
            if (gameObject.transform.position == (spawns[x].gameObject.transform.position + new Vector3(0, 1.023f,0))) {

                if (potionC) { bottleEndurance.SetActive(true); potionC = false; }
                if (potionB) { bottleHealth.SetActive(true); potionB = false; }
                if (potionA) { bottleMana.SetActive(true); potionA = false; }

            }
        }

        
    }


    private IEnumerator loadscene(string scene)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

       
        while (!operation.isDone)
        {
            //girar moneda
            yield return null;
        }

        yield return null;


    }

    private IEnumerator ActivateKey() {

        partcls.SetActive(true);
        yield return new WaitForSeconds(7.6f);
        key.SetActive(true);
        partcls.SetActive(false);
        

    }


}
