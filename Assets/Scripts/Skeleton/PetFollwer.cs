using UnityEngine;

public class PetFollwer
{
    private readonly Rigidbody _rd;

    public PetFollwer(Rigidbody rd)
    {
        _rd = rd;
    }

    public void Move(Vector3 targetPosition, float moveSpeed)
    {
        Vector3 toTarget = targetPosition - _rd.position;

        // 너무 가까우면 이동하지 않음
        if (toTarget.sqrMagnitude < 0.01f) return; // 거리 0.1 이하에서 멈춤

        Vector3 direction = toTarget.normalized;
        _rd.MovePosition(_rd.position + direction * moveSpeed * Time.fixedDeltaTime);
    }


}
