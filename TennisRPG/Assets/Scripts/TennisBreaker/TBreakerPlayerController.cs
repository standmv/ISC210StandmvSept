using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBreakerPlayerController : MonoBehaviour
{
    bool _cpuPlayer = true;
    public GameObject Ball;
    bool _isPlayerOne;
    float _movementSpeed = 0.5f;
    Vector3 _deltaPos;
    const float _LOWERLIMIT = -7.6f, _UPPERLIMIT = 7.6f;
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
            _deltaPos = new Vector3(_movementSpeed * Input.GetAxis(_isPlayerOne ? "Horizontal" : "Player2"), 0);
            transform.Translate(_deltaPos);
        }
        else if (!_isPlayerOne && Ball != null)
        {
            _deltaPos = Vector3.Lerp(Ball.transform.position, gameObject.transform.position, 0.8f);
            _deltaPos.x = transform.position.x;
            transform.position = _deltaPos;
        }

        transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, _LOWERLIMIT, _UPPERLIMIT), gameObject.transform.position.y,
            gameObject.transform.position.z);
    }
}
