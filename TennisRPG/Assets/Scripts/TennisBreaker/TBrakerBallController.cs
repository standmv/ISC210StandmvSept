﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBrakerBallController : MonoBehaviour
{
    float _startingForceScalar = 5f;
    Vector3 startingForce;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && transform.parent != null)
        {
            //start playing
            startingForce = Vector3.zero;
            startingForce.y = transform.parent.tag == "Player" ? 1 : -1;
            startingForce.x = Random.Range(0, 2) == 0 ? 1 : -1;
            startingForce *= _startingForceScalar;
            transform.SetParent(null);

            //gameObject.GetComponent<Rigidbody>().addForce(startingForce);
            gameObject.GetComponent<Rigidbody>().velocity = startingForce;
        }
    }
}
