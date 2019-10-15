using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPowerUpController : MonoBehaviour
{
    float _powerUpTimeElapsed = 0;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        _powerUpTimeElapsed += Time.deltaTime;
        if (_powerUpTimeElapsed >= 8)
            Destroy(gameObject);
    }
}
