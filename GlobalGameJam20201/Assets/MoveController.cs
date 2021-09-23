using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MoveController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 3f;
    public Rigidbody2D rb;
    Vector2 movement;
    int heartCount = 0;
    [SerializeField]
    public Sprite[] spriteArray;
    [SerializeField]
    private float time;
    public SpriteRenderer spriteRenderer;
    [SerializeField]
    GameObject uiText;
    
    Scene currentScene;

    // Start is called before the first frame update
    void Start()
    {        
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[heartCount];
        uiText = GameObject.Find("TimerText");
        time = 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            heartCount++;
        }
        spriteRenderer.sprite = spriteArray[heartCount];

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.2f, 6.2f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f), transform.position.z);


        time -= Time.deltaTime;        
        uiText.gameObject.GetComponent<Text>().text = time.ToString("F0");

        if (time <= 0)
        {
            currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }

        if(heartCount >= 6)
        {
            SceneManager.LoadScene("End");
        }

    }

    public void addHeart()
    {
        heartCount++;
    }

    private void FixedUpdate()
    {        
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


}
