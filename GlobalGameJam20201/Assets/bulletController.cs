using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{

    [SerializeField]
    GameObject playerHeart;

    int spawnX;
    int spawnY;

    [SerializeField]
    Vector3 targetPos;

    [SerializeField]
    int bulletSpeed;

    [SerializeField]
    GameObject bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        playerHeart = GameObject.FindGameObjectWithTag("Player");
        spawnX = Random.Range(-15, 15);
        spawnY = Random.Range(6, 7);

        targetPos = new Vector3((spawnX * -1), (spawnY * -1), 0);

        transform.position = new Vector3(spawnX, spawnY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * bulletSpeed);

        if (transform.position == targetPos)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision == playerHeart)
        {
            playerHeart.GetComponent<MoveController>().addHeart();   
            Debug.Log("Love ya");
        }
        else
        {
            Instantiate(bulletSpawn);

            Destroy(this.gameObject);
        }
    }
}
