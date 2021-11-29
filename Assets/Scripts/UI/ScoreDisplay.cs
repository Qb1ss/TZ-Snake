using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private int _crystalCount;

    private TextMeshProUGUI _scoreDisplay;


    private void Start()
    {
        _scoreDisplay = GetComponent<TextMeshProUGUI>();
    }


    public void OnAddCrystal()
    {
        _crystalCount++;

        _scoreDisplay.text = _crystalCount.ToString();
    }
}