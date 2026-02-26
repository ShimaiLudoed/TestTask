using UnityEngine;
using System;
using VContainer;
public class ScoreView : MonoBehaviour
{
    [SerializeField] private int score;
    [Inject] private TextData _textData;
    
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
