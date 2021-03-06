﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	bool _cpuPlayer = true;
	public GameObject Ball;
	bool _isPlayerOne;
	float _movementSpeed = 0.5f;
	Vector3 _deltaPos;
	const float _LOWERLIMIT = -2.9f, _UPPERLIMIT = 2.9f;
	Animator _animator;
    ScoreCounter _scoreCounter;
    void Awake()
	{
		_animator = GetComponent<Animator>();
	}
    // Start is called before the first frame update
	void Start()
    {
        _isPlayerOne = name == "Player1";
        _scoreCounter = GameObject.Find("GlobalScripts").GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_cpuPlayer || _isPlayerOne)
        {
            _deltaPos = new Vector3(0, _movementSpeed * Input.GetAxis(_isPlayerOne ? "Player1" : "Player2"));
            transform.Translate(_deltaPos);

			if (_animator != null)
				_animator.SetFloat("SpeedY", _deltaPos.y);
        }
        else if (!_isPlayerOne && Ball != null)
        {
            _deltaPos = Vector3.Lerp(Ball.transform.position, gameObject.transform.position, 0.8f);
            _deltaPos.x = transform.position.x;
            transform.position = _deltaPos;
        }

        transform.position = new Vector3(gameObject.transform.position.x,
            Mathf.Clamp(gameObject.transform.position.y, _LOWERLIMIT, _UPPERLIMIT),
            gameObject.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreCounter.ScoreType scoreType;
        try
        {
            scoreType = (ScoreCounter.ScoreType)Enum.Parse(typeof(ScoreCounter.ScoreType), other.gameObject.tag);
        }
        catch (Exception)
        {
            return;
        }

        if (scoreType == ScoreCounter.ScoreType.Trap)
            _scoreCounter.UpdateScore(ScoreCounter.ScoreType.Life, -1);
        else
            _scoreCounter.UpdateScore(scoreType);
        Destroy(other.gameObject);

        if (_scoreCounter.GetLifeScore() <= 0)
            Debug.Log("Game Over");
    }
}
