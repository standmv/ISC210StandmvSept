using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PB_PlayerController : MonoBehaviour
{
    bool _cpuPlayer = false;
    public GameObject Ball;
    bool _isPlayerOne;
    float _movementSpeed = 0.5f;
    Vector3 _deltaPos;
    const float _LOWERLIMIT = -2.9f, _UPPERLIMIT = 2.9f;
    // Start is called before the first frame update
    void Start()
    {
        _isPlayerOne = name == "Player1";
    }

    // Update is called once per frame
    void Update()
    {
        if (!_cpuPlayer || _isPlayerOne)
        {
            _deltaPos = new Vector3(_movementSpeed * Input.GetAxis(_isPlayerOne ? "Player1" : "Player2"), _movementSpeed * Input.GetAxis(_isPlayerOne ? "Player1" : "Player2"));
            transform.Translate(_deltaPos);
        }
        else if (!_isPlayerOne && Ball != null)
        {
            _deltaPos = Vector3.Lerp(Ball.transform.position, gameObject.transform.position, 0.8f);
            _deltaPos.x = transform.position.x;
            transform.position = _deltaPos;
        }

        transform.localPosition = new Vector3(Mathf.Sin(gameObject.transform.localPosition.x),
            Mathf.Cos(gameObject.transform.localPosition.y),
            0);
    }
}
