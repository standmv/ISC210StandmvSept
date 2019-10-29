using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class Score
{
    public int score;
    public float time;
}

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMesh ScoreText;
    public int _score = 0;
    public TextMesh LivesText;
    public int _lives;
    const int LIVES = 3;
    bool _gameEnded;
    void Start()
    {
        _lives = LIVES;
        LivesText.text = _lives.ToString();
        ScoreText.text = _score.ToString();
        _gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_lives == 0 && _gameEnded != true)
        {
            Score newScore = new Score
            {
                score = _score,
                time = Time.time
            };
            StartCoroutine(PostRequest("http://localhost:8080/tbscore", JsonUtility.ToJson(newScore)));
            _gameEnded = true;
            Application.Quit();
        }
    }

    IEnumerator PostRequest(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        Debug.Log("Response: " + request.downloadHandler.text);
    }
}
