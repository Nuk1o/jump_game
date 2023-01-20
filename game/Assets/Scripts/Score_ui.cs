using System;
using TMPro;
using UnityEngine;

public class Score_ui : MonoBehaviour
{
    private TextMeshProUGUI _field;
    private int _score;

    private void Awake()
    {
        _field = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _field.text = _score.ToString();
    }

    public void IncreaseScore()
    {
        _score += 1;
        _field.text = _score.ToString();
    }
}
