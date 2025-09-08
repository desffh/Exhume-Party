using UnityEngine;

public class Rotation
{
    private readonly Transform _transform;

    public Rotation(Transform transform)
    {
        _transform = transform;
    }

    public void Rotate(Vector3 direction, float rotateSpeed)
    {
        if (direction != Vector3.zero)
        {
            // 지금 바라보는 방향의 부호 != 나아갈 방향 부호라면 조금만 회전
            if (Mathf.Sign(direction.x) != Mathf.Sign(_transform.position.x) ||
                Mathf.Sign(direction.z) != Mathf.Sign(_transform.position.z))
            {
                _transform.Rotate(0, 1, 0);
            }

            _transform.forward = Vector3.Lerp(_transform.forward, direction, rotateSpeed * Time.deltaTime);
        }
    }
}
