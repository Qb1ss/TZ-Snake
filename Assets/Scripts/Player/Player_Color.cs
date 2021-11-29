using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerColors
{
    Blue,
    Gray,
    Green,
    Orange,
    Red,
    Yellow
}

public class Player_Color : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private PlayerColors _colors;

    [HideInInspector] public Color PlayerColor;

    [Header("Tails")]
    [SerializeField] private Player_SnackController[] _player_SnackController;
    private Renderer _playerRenderer;


    private void Start()
    {
        _playerRenderer = GetComponent<Renderer>();

        GetColor();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<ColorPanel>(out ColorPanel colorPanel))
        {
            _playerRenderer.material.color = colorPanel.PanelColor;

            for (int i = 0; 0 <= _player_SnackController.Length; i++)
            {
                if (i % 2 != 0)
                {
                    _player_SnackController[i].GetComponent<Renderer>().material.color = colorPanel.PanelColor;
                }
                else if (i == _player_SnackController.Length)
                {
                    break;
                }
            }
        }
        else if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (_playerRenderer.material.color == enemy.EnemyColor)
            {
                Destroy(enemy.gameObject);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }


    #region GetColor
    private void GetColor()
    {
        if (_colors == PlayerColors.Blue)
        {
            PlayerColor = Color.blue;
        }
        else if (_colors == PlayerColors.Gray)
        {
            PlayerColor = Color.gray;
        }
        else if (_colors == PlayerColors.Green)
        {
            PlayerColor = Color.green;
        }
        else if (_colors == PlayerColors.Orange)
        {
            PlayerColor = new Color(1, 0.6470588f, 0);
        }
        else if (_colors == PlayerColors.Red)
        {
            PlayerColor = Color.red;
        }
        else if (_colors == PlayerColors.Yellow)
        {
            PlayerColor = Color.yellow;
        }

        _playerRenderer.material.color = PlayerColor;

        for (int i = 0; 0 <= _player_SnackController.Length; i++)
        {
            if (i % 2 != 0)
            {
                _player_SnackController[i].GetComponent<Renderer>().material.color = PlayerColor;
            }
            else if (i == _player_SnackController.Length)
            {
                break;
            }
        }
    }
    #endregion
}