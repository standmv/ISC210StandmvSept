using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBreakerDeadZoneController : MonoBehaviour
{
    public TextMesh LivesText;
    public GameObject PlayerOne;
    public static int lives = 3;
    public GameObject Ball;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (other.name == "Ball")
        {
            lives--;
            LivesText.text = lives.ToString();
            Ball.transform.SetParent(PlayerOne.transform);
            Ball.transform.localPosition = new Vector3(0, 2.5f);
        }
    }
}
