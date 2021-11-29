using UnityEngine;

public enum PanelColors
{
    Blue,
    Gray,
    Green,
    Orange,
    Red,
    Yellow
}


public class ColorPanel : MonoBehaviour
{
    [Header ("Color")]
    [SerializeField] private PanelColors _colors;

    [HideInInspector] public Color PanelColor;

    private Renderer _playerRenderer;


    private void Start()
    {
        _playerRenderer = GetComponent<Renderer>();

        GetColor();
    }

    #region GetColor
    private void GetColor()
    {
        if (_colors == PanelColors.Blue)
        {
            PanelColor = Color.blue;
        }
        else if (_colors == PanelColors.Gray)
        {
            PanelColor = Color.gray;
        }
        else if (_colors == PanelColors.Green)
        {
            PanelColor = Color.green;
        }
        else if (_colors == PanelColors.Orange)
        {
            PanelColor = new Color(1, 0.6470588f, 0);
        }
        else if (_colors == PanelColors.Red)
        {
            PanelColor = Color.red;
        }
        else if (_colors == PanelColors.Yellow)
        {
            PanelColor = Color.yellow;
        }

        _playerRenderer.material.color = PanelColor;
    }
    #endregion
}