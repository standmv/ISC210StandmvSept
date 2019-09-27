using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class Scores
{
	public int Id;
	public string PlayerName;
	public int Score;
}
public class WebServiceClient : MonoBehaviour
{

	UnityWebRequest www;
	void Awake()
	{
	    
	}
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Fire3"))
		{
			StartCoroutine(SendPostRequest("http://localhost:8080/score"));
		}
	}

	IEnumerator SendRequest(string url)
	{
		UnityWebRequest webRequest = UnityWebRequest.Get(url);

		yield return webRequest.SendWebRequest();

		if (www.isHttpError || www.isNetworkError)
			Debug.Log("No se logro obtener el listado de los jugadores");

		else
			Debug.Log(webRequest.downloadHandler.text);
	}

	IEnumerator SendPostRequest(string url)
	{
		Scores newScore = new Scores
		{
			PlayerName = "Stanley De Moya",
			Score = DeadZoneController._scoreOne
		};

		www = UnityWebRequest.Post(url, JsonUtility.ToJson(newScore));
		www.SetRequestHeader("Content-Type", "application/json");

		yield return www.SendWebRequest();

		Debug.Log(www.downloadHandler.text);
	}
}