using UnityEngine;

public class Player_SnackController : MonoBehaviour
{
    [SerializeField] private Transform target;

    private float _targetDistance = 1;

    public void Update()
    {
        Vector3 direction = target.position - transform.position;
        float distance = direction.magnitude;

        if (distance > _targetDistance)
        {
            transform.position += direction.normalized * (distance - _targetDistance);
            transform.LookAt(target);
        }
    }
}