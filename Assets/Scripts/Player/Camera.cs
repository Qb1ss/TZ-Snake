using UnityEngine;

public class Camera : MonoBehaviour
{
    [Header("Camera Parameters")]
    [SerializeField] private float _cameraSmooth = 5f;

    [SerializeField] private Vector3 _cameraOffset = new Vector3(0.5f, 9, -3);

    private Player_Movement _player_Movement;


    private void Start()
    {
        _player_Movement = GameObject.FindObjectOfType<Player_Movement>();
    }


    void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(0, 0 , _player_Movement.transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition + _cameraOffset, Time.deltaTime * _cameraSmooth);
    }
}
