using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    // Start is called before the first frame update
    private int _fijiScore = 0, _melonSodaScore = 0, _peachSodaScore = 0, _spriteScore = 0, _waterScore = 0, _lifeScore = 3;
    public TextMesh FijiScoreText;
    public TextMesh MelonSodaScoreText;
    public TextMesh PeachSodaScoreText;
    public TextMesh SpriteScoreText;
    public TextMesh WaterScoreText;
    public TextMesh LifeScore;
    public enum ScoreType
    {
        Fiji,
        MelonSoda,
        PeachSoda,
        Sprite,
        Water,
        Life,
        All,
        Trap
    }

    public int GetLifeScore()
    {
        return _lifeScore;
    }

    void Start()
    {
        UpdateScoreText(ScoreType.All);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(ScoreType scoreType, int value = 1)
    {
        switch (scoreType)
        {
            case ScoreType.Fiji:
                _fijiScore += value;
                UpdateScoreText(ScoreType.Fiji);
                break;
            case ScoreType.MelonSoda:
                _melonSodaScore += value;
                UpdateScoreText(ScoreType.MelonSoda);
                break;
            case ScoreType.PeachSoda:
                _peachSodaScore += value;
                UpdateScoreText(ScoreType.PeachSoda);
                break;
            case ScoreType.Sprite:
                _spriteScore += value;
                UpdateScoreText(ScoreType.Sprite);
                break;
            case ScoreType.Water:
                _waterScore += value;
                UpdateScoreText(ScoreType.Water);
                break;
            case ScoreType.Life:
                _lifeScore += value;
                UpdateScoreText(ScoreType.Life);
                break;
        }
    }

    void UpdateScoreText(ScoreType scoreType)
    {
        if (scoreType == ScoreType.All || scoreType == ScoreType.Fiji)
            FijiScoreText.text = _fijiScore.ToString();
        if (scoreType == ScoreType.All || scoreType == ScoreType.MelonSoda)
            MelonSodaScoreText.text = _melonSodaScore.ToString();
        if (scoreType == ScoreType.All || scoreType == ScoreType.PeachSoda)
            PeachSodaScoreText.text = _peachSodaScore.ToString();
        if (scoreType == ScoreType.All || scoreType == ScoreType.Sprite)
            SpriteScoreText.text = _spriteScore.ToString();
        if (scoreType == ScoreType.All || scoreType == ScoreType.Water)
            WaterScoreText.text = _waterScore.ToString();
        if (scoreType == ScoreType.All || scoreType == ScoreType.Life)
            LifeScore.text = _lifeScore.ToString();
    }
}
