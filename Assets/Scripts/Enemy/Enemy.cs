using UnityEngine;

public enum EnemyColors
{
    Blue,
    Gray,
    Green,
    Orange,
    Red,
    Yellow
}

public class Enemy : MonoBehaviour
{
    [Header("Color")]
    [SerializeField] private EnemyColors _colors;

    [HideInInspector] public Color EnemyColor;

    private Renderer _playerRenderer;


    private void Start()
    {
        _playerRenderer = GetComponent<Renderer>();

        GetColor();
    }


    #region GetColor
    private void GetColor()
    {
        if (_colors == EnemyColors.Blue)
        {
            EnemyColor = Color.blue;
        }
        else if (_colors == EnemyColors.Gray)
        {
            EnemyColor = Color.gray;
        }
        else if (_colors == EnemyColors.Green)
        {
            EnemyColor = Color.green;
        }
        else if (_colors == EnemyColors.Orange)
        {
            EnemyColor = new Color(1, 0.6470588f, 0);
        }
        else if (_colors == EnemyColors.Red)
        {
            EnemyColor = Color.red;
        }
        else if (_colors == EnemyColors.Yellow)
        {
            EnemyColor = Color.yellow;
        }

        _playerRenderer.material.color = EnemyColor;
    }
    #endregion
}