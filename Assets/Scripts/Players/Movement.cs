using UnityEngine;

public class Movement
{
    private readonly Rigidbody _rd;

    public Movement(Rigidbody rd)
    {
        _rd = rd;
    }

    public void Move(Vector3 direction, float moveSpeed)
    {
        _rd.MovePosition(_rd.position + direction * moveSpeed * Time.deltaTime);
    }
}
