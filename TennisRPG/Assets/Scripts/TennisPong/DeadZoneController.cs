using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneController : MonoBehaviour
{
	public TextMesh PlayerOneText, PlayerTwoText;
	public GameObject PlayerOne, PlayerTwo;
	static int _scoreOne, _scoreTwo;
	public GameObject Ball;
	bool _playerOneScored;
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
		if (other.gameObject.name != "tenis_ball")
			return;
		_playerOneScored = gameObject.name == "PlayerTwoDeadZone";
		Ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
		if (_playerOneScored)
		{
			_scoreOne++;
			PlayerOneText.text = _scoreOne.ToString();
			Ball.transform.SetParent(PlayerOne.transform);
			Ball.transform.localPosition = new Vector3(2.5f, 0);
		}

		else
		{
			_scoreTwo++;
			PlayerTwoText.text = _scoreTwo.ToString();
			Ball.transform.SetParent(PlayerTwo.transform);
			Ball.transform.localPosition = new Vector3(-2.4f, 0);
		}
	}
}
