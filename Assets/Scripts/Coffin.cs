using System;
using UnityEngine;

public class Coffin : MonoBehaviour
{
    private GameObject Area;

    private State currentState;

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case State.GO_GOAL:
                MoveTowards(Area.transform.position);
                break;
        }
    }

    public void AssignTarget(GameObject area)
    {
        currentState = State.GO_GOAL;
        Area = area;
    }

    private void MoveTowards(Vector3 target)
    {
        Vector3 dir = (target - transform.position).normalized;
        transform.position += dir * Time.fixedDeltaTime * 5f; // 속도 하드코딩 예시
    }
}
