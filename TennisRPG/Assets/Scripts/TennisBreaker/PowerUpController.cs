using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    // Start is called before the first frame update
    int _powerUpType;
    public GameObject BigPlayerOne;
    public GameObject SmallPlayerOne;
    public GameObject BonusPowerUp;
    void Start()
    {
        _powerUpType = Random.Range(1,3);
        //_powerUpType = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject instantiatePowerUp = null;
            switch (_powerUpType)
            {
                case 1:
                    instantiatePowerUp = BigPlayerOne;
                    break;
                case 2:
                    instantiatePowerUp = SmallPlayerOne;
                    break;
                case 3:
                    instantiatePowerUp = BonusPowerUp;
                    break;
            }
            if (_powerUpType == 3)
            {
                Instantiate(instantiatePowerUp, new Vector3(0, 7, 0), Quaternion.identity);
                Destroy(gameObject);
            }
                
            else
            {
                Instantiate(instantiatePowerUp, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, 0), Quaternion.identity);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
    }

}
