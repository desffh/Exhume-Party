using UnityEngine;

public class PetRotation
{
    private readonly Transform _transform;

    public PetRotation(Transform transform)
    {
        _transform = transform;
    }

    public void Rotate(Vector3 direction, float rotateSpeed)
    {
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
    }
}
