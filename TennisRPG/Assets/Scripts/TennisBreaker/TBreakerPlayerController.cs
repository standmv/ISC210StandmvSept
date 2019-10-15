using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBreakerPlayerController : MonoBehaviour
{
   
    bool _isPlayerOne;
    float _movementSpeed = 0.5f;
    Vector3 _deltaPos;
    const float _LOWERLIMIT = -7.4f, _UPPERLIMIT = 7.4f;
    float _powerUpTimeElapsed = 0;
    bool _isPowerUp = false;
    public GameObject PlayerOne;
    // Start is called before the first frame update
    void Start()
    {
        //_isPlayerOne = name == "Player1";
        _isPlayerOne = tag == "Player";
        _isPowerUp = name != "Player1";
    }

    // Update is called once per frame
    void Update()
    {
        _deltaPos = new Vector3(_movementSpeed * Input.GetAxis(_isPlayerOne ? "Horizontal" : "Player2"), 0);
        transform.Translate(_deltaPos);
        transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, _LOWERLIMIT, _UPPERLIMIT), gameObject.transform.position.y,
            gameObject.transform.position.z);
        if (_isPowerUp)
            _powerUpTimeElapsed += Time.deltaTime;
        if(_powerUpTimeElapsed >= 5 && PlayerOne!=null)
        {
            Instantiate(PlayerOne, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            Destroy(gameObject);
            
        }
       

    }

    private void OnDestroy()
    {
        transform.DetachChildren();
    }
}
