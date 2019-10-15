using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBreakerDeadZoneController : MonoBehaviour
{
    
    GameObject PlayerOne;
    public GameObject Ball;
    GameController gameController;
	// Start is called before the first frame update
	void Start()
    {
        gameController = GameObject.Find("GlobalScripts").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball")
        {
            gameController._lives--;
			gameController.LivesText.text = gameController._lives.ToString();
	        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            PlayerOne = GameObject.FindWithTag("Player");
			Ball.transform.SetParent(PlayerOne.transform);
            Ball.transform.localPosition = new Vector3(0, 1f);

            DestroyAllPowerUps();
        }

        if(other.name == "PowerUp")
        {
            Destroy(other.gameObject);
        }
    }

    public void DestroyAllPowerUps()
    {
        GameObject[] gameObjects;

        gameObjects = GameObject.FindGameObjectsWithTag("PowerUp");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }
}
