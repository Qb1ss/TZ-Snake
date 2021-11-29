using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player_Movement : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float _movingSpeed = 5;
    [SerializeField] private float _distance = 2;
    [Space(height: 5f)]

    [SerializeField] private float _timerFever = 5;
    private float _btwTimerFever = 0;

    private bool _isFever;
    [Space(height: 5f)]

    public int Length = 7;

    [Header("Crystals")]
    [SerializeField] private int _needCrystal = 3;
    [HideInInspector] public int CrystalCount;

    private ScoreDisplay _scoreDisplay;
    private Rigidbody _rigidbody;
    private Vector3 _startPosition;

    private const float _dividingSpeedTurnConst = 10;
    private const float _multiplicationMovingSpeedConst = 2;


    private void Start()
    {
        _scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();

        _rigidbody = GetComponent<Rigidbody>();

        _startPosition = new Vector3(0, 0, 0);
    }


    private void FixedUpdate()
    {
        Movement();
    }


    private void Movement()
    {
        transform.position += Vector3.forward * _movingSpeed * Time.fixedDeltaTime;

        if (_isFever == true)
        {
            Vector3 targetPositions = new Vector3(0, transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPositions, _movingSpeed / _dividingSpeedTurnConst);

            _btwTimerFever += Time.deltaTime;

            if (_btwTimerFever >= _timerFever)
            {
                _isFever = false;

                _btwTimerFever = 0;
            }
        }
    }


    public void TurningLeft()
    {
        if (_isFever == false)
        {
            Vector3 targetPositions = new Vector3(_startPosition.x - _distance, transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPositions, _movingSpeed / _dividingSpeedTurnConst);
            transform.position = new Vector3(targetPositions.x, transform.position.y, transform.position.z);
        }
    }


    public void TurningRight()
    {
        if (_isFever == false)
        {
            Vector3 targetPositions = new Vector3(_startPosition.x + _distance, transform.position.y, transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, targetPositions, _movingSpeed / _dividingSpeedTurnConst); 
            transform.position = new Vector3(targetPositions.x, transform.position.y, transform.position.z);
        }
    }


    public void TurningButtonsUp()
    {
        Vector3 targetPositions = new Vector3(_startPosition.x, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPositions, _movingSpeed / _dividingSpeedTurnConst); 
        transform.position = new Vector3(_startPosition.x, transform.position.y, transform.position.z);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Trap>(out Trap trap))
        {
            SceneManager.LoadScene(0);
        }
        else if (other.gameObject.TryGetComponent<Crystal>(out Crystal crystal))
        {
            Destroy(crystal.gameObject);

            SetCrystal();
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(0);
        }
    }


    private void SetCrystal()
    {
        CrystalCount++;

        if (CrystalCount >= _needCrystal)
        {
            _isFever = true;

            CrystalCount = 0;
        }

        _scoreDisplay.OnAddCrystal();
    }
}