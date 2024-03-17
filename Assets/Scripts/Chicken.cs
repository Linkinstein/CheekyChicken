using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Chicken : MonoBehaviour
{
    [SerializeField] private AudioClip hitSound;
    [SerializeField] public Sprite skinSprite;
    [SerializeField] public Sprite chickenStun;
    [SerializeField] private GameObject eggGO;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D cc2d;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private AudioSource ads;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI eggCountText;
    [SerializeField] private TextMeshProUGUI newhighscoretext;
    [SerializeField] private GameObject[] Spawners;
    [SerializeField] private float moveSpeed;

    public int level = 1;
    private int score = 0;
    private float timeLeft = 90;
    private bool paused = false;
    public bool gameover = false;

    private bool[] pickedEggs = new bool[6];
    private int eggs = 0;

    private int _x = 1;

    private int collisionStrength = 10;
    private bool stunned = false;
    private bool stunImmune = false;

    public int x
    {
        get { return _x; }
        set
        {
            if (value < 0) sr.flipX = true;
            else sr.flipX = false;
            _x = value;
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 1f;
    }

    private void Start()
    {
        sr.sprite = skinSprite;
    }

    private void Update()
    {
        eggCountText.SetText(eggs+"");
        timerText.SetText(Mathf.Clamp(Mathf.FloorToInt(timeLeft -= Time.deltaTime), 0f, 90f) + "");
        if (timeLeft < 0f)
        {
            Time.timeScale = 0f;
            gameover = true;
            gameOverMenu.SetActive(true);
            gameOverText.SetText(score+"");
            string scoreID = "hiscore" + level;
            if (PlayerPrefs.HasKey(scoreID))
            {
                if (score > PlayerPrefs.GetFloat(scoreID))
                {
                    PlayerPrefs.SetInt(scoreID, score);
                    newhighscoretext.SetText("New Highscore!");
                }
            }
            else
            {
                PlayerPrefs.SetInt(scoreID, score);
                newhighscoretext.SetText("New Highscore!");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !gameover)
        {
            if (paused) 
            { 
                Time.timeScale = 1f; 
                paused = false;
                pauseMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0f;
                paused = true;
                pauseMenu.SetActive(true);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!stunned)
        {
            if (Input.GetAxis("Horizontal") != 0) x = (int)Mathf.Sign(Input.GetAxis("Horizontal"));
            float slow = 1 - (0.1f * eggs);
            rb.velocity = new Vector2((Input.GetAxis("Horizontal") * moveSpeed)* Mathf.Clamp(slow, 0.1f, 1f), (Input.GetAxis("Vertical") * moveSpeed) * Mathf.Clamp(slow, 0.1f, 1f));
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            ResetEggs();
            if (!stunned) StartCoroutine(CarCrash());
            stunned = true;
            if(!stunImmune)rb.velocity = new Vector2((gameObject.transform.position.x - collision.transform.position.x) * collisionStrength, (gameObject.transform.position.y - collision.transform.position.y) * collisionStrength);
            
        }

        if (collision.gameObject.CompareTag("Egg"))
        {
            eggGO.SetActive(true);
            eggs++;
            gameObject.transform.localScale += new Vector3(0.05f, -0.05f, 0f);
            pickedEggs[collision.gameObject.GetComponent<Egg>().number] = true;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Homebase"))
        {
            score += eggs;
            ResetEggs();
        }
    }

    IEnumerator CarCrash()
    {
        ads.PlayOneShot(hitSound);
        sr.sprite = chickenStun;
        yield return new WaitForSeconds(0.5f);
        stunImmune = true;
        rb.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(1f);
        sr.sprite = skinSprite;
        stunned = false;
        cc2d.enabled = false;
        yield return new WaitForSeconds(0.5f);
        cc2d.enabled = true;
    }

    private void ResetEggs()
    {
        eggGO.SetActive(false);
        gameObject.transform.localScale = Vector3.one;
        eggs = 0;
        for (int i = 0; i < pickedEggs.Length; i++)
        {
            if (pickedEggs[i]) StartCoroutine(Spawners[i].GetComponent<EggSpawner>().Spawning());
            pickedEggs[i] = false;
        }
    }
}
