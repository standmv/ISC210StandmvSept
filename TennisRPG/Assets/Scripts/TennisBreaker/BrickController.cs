using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    // Start is called before the first frame update
    GameController gameController;
    public GameObject PowerUp;
    public Sprite brokenBrick;
    int hits;
    int _containsPowerUp;
    public int multiplier = 1;
    void Start()
    {
        hits = gameObject.tag == "Brick" ? 1 : 2;
        gameController = GameObject.Find("GlobalScripts").GetComponent<GameController>();
        _containsPowerUp = Random.Range(1, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        //probando si puedo cambiar la velocidad de la pelota desde los bricks
        //other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        hits--;
        if(hits == 0)
        {
            Destroy(gameObject);
        }
        
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            if (_containsPowerUp == 1)
                Instantiate(PowerUp, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            hits--;
            if (hits == 0)
            {
                Destroy(gameObject);
                if (GameObject.FindGameObjectWithTag("Bonus"))
                    gameController._score += 2;
                else 
                    gameController._score++;
                gameController.ScoreText.text = gameController._score.ToString();
            }
            else if (hits == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = brokenBrick;
            }
        }

    }


}
