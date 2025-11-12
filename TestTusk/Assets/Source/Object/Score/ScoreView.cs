using UnityEngine;
using System;
using Zenject;
public class ScoreView : MonoBehaviour
{
    [SerializeField] private int score;
    private TextData _textData;
    
    [Inject]
    public void Construct(TextData textData)
    {
        _textData = textData;
    }

    private void Start()
    {
       UpdateText();
        Debug.Log(_textData);
    }

    public void AddScore()
    {
        score++;
        UpdateText();
    }
    private void UpdateText()
    {
        _textData.Score.text = "Score: " + score.ToString();
    }
}
