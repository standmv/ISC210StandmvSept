using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
        _deltaPos = new Vector3(0,_movementSpeed * Input.GetAxis(_isPlayerOne ? "Player1" : "Player2"));
		transform.Translate(_deltaPos);
        transform.position = new Vector3(gameObject.transform.position.x,
            Mathf.Clamp(gameObject.transform.position.y, _LOWERLIMIT, _UPPERLIMIT),
            gameObject.transform.position.z);
    }
}
