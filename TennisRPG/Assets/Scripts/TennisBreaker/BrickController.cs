using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    // Start is called before the first frame update
    int hits;
    void Start()
    {
        hits = gameObject.name == "Brick" ? 1 : 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //probando si puedo cambiar la velocidad de la pelota desde los bricks
        other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        hits--;
        if(hits == 0)
        {
            Destroy(this);
        }
        
    }


}
