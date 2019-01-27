using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    private float moveHorizontal;
    private float moveVertical;
    public float jumpSpeed = 5.0f;
    public float jump;
    private bool isgrounded;
    public bool finishCamera = false;
    private Rigidbody rb;
    float Timer = 0.0f;
    public Text TimeText;
    public GameObject GameOverGui;
    public GameObject WinGui;
    public GameObject MainMenu;
    private MenuHandler mh;
    private bool won;
    private bool lost;
    public bool showingMenu;
    PlayerData playerData;

    void Start()
    {
        mh = new MenuHandler();
        playerData = new PlayerData(mh.maxScenes());
        rb = GetComponent<Rigidbody>();
        TimeText.text = "Time: " + Timer.ToString().Substring(0,4);
        won = false;
        lost = false;
        showingMenu = false;
        GameOverGui.SetActive(false);
        WinGui.SetActive(false);
        playerData = PlayerData.Load(Application.persistentDataPath + "/PlayerInfo.dat");
    }

    private void Update()
    {
        if (!won)
        {
            Timer += Time.deltaTime;
        }
        TimeText.text = "Time: " + Timer.ToString().Substring(0, 4);

        if (Input.GetKey(KeyCode.R))
        {
            mh.reloadScene();
            print("up arrow key is held down");
        }
        if (showingMenu && mh.storytime)
        {
            if (Input.GetKey(KeyCode.N))
            {
                mh.nextStory();
                print("next story");
            }
        }
        if (showingMenu && won)
        {
            if (Input.GetKey(KeyCode.N))
            {
                mh.LoadScene();
                print("up arrow key is held down");
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            mh.ShowMenu();
            print("up arrow key is held down");
        }

    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        moveHorizontal *= 1.5f;
        moveVertical *= 1.5f;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed, ForceMode.Force);
        if (Input.GetButton("Jump"))
        {
            jump = Input.GetAxis("Jump");
            Debug.Log("isgrounded: " + isgrounded);
            if (isgrounded)
            {
                jump = jump * jumpSpeed;

            }
            else
            {
                Debug.Log("Can't jump, i am flying");
            }
        }
        else
        {
            jump = 0;
        }
        Vector3 jumpMovement = new Vector3(0.0f, jump, 0.0f);
        rb.AddForce(jumpMovement * speed, ForceMode.Force);

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "Road")
        {
            isgrounded = true;
            Debug.Log("Enter: " + isgrounded);
        }
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("Finish Line");
            displayUiElements("win");
            finishCamera = true;
            Explode(collision);
        }
        if (collision.gameObject.tag == "Terrain")
        {
            isgrounded = true;
            Invoke("setCamera", 4);
            displayUiElements("lose");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            isgrounded = false;
            Debug.Log("Exit: " + isgrounded);
        }
    }

    void Explode(Collision collision)
    {
        var exp = collision.gameObject.GetComponentInChildren<ParticleSystem>();
        exp.Play();
        Invoke("Catapult", 4);
    }
    void Catapult()
    {
        jump = 10.0f;
        Vector3 jumpMovement = new Vector3(0.0f, jump, 0.0f);
        rb.AddForce(jumpMovement * speed, ForceMode.Impulse);
    }

    private void displayUiElements(string state)
    {
        showingMenu = true;
        if(state == "win")
        {
            won = true;
            WinGui.SetActive(true);
            
        }
        else if(state == "lose")
        {
            lost = true;
            GameOverGui.SetActive(true);
        }
    }
    private void HighscoreHandling()
    {
        MenuHandler mh = new MenuHandler();
        playerData.SetScore(mh.currentSceneId(), Timer);
        playerData.Save(Application.persistentDataPath + "/PlayerInfo.dat");

    }

    private void setCamera()
    {
        finishCamera = false;
    }
}
