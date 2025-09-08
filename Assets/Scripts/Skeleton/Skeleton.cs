using System;
using Unity.VisualScripting;
using UnityEngine;

enum State
{
    IDLE,
    GO_TARGET,
    GO_GOAL,
    STAY
}

public class Skeleton : MonoBehaviour
{
    [SerializeField] float _miningSpeed = 5.0f;
    [SerializeField] float _moveSpeed = 10.0f;
    [SerializeField] float _rotateSpeed = 15.0f;

    private Rigidbody rb;
    private Animator ani;

    private Vector3 targetPos;
    private Formation formation;

    private int index;
    private bool isRun;

    #region 펫 내부 클래스
    private PetFollwer _petFollwer;
    private PetRotation _Rotation;
    private PetAnime _Anime;
    #endregion

    private State currentState = State.IDLE;
    private GameObject Target; // 목표 타겟 위치
    private GameObject Area; // 목표 도달 위치



    public float MiningSpeed { get { return _miningSpeed; } set { SetMiningSpeed(value); } }
    public float MoveSpeed { get { return _moveSpeed; } set { SetMoveSpeed(value); } }


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        _petFollwer = new PetFollwer(rb);
        _Rotation = new PetRotation(transform);
        _Anime = new PetAnime(ani);
    }

    public void Initialize(Formation formation, int index)
    {
        this.formation = formation;
        this.index = index;
    }


    private void Update()
    {
        _Anime.Running(isRun);
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case State.IDLE:
                // 플레이어 뒤 formation 따라다님
                targetPos = formation.GetWorldTargetPos(index); // 실시간으로 인덱스 위치 계산
                _petFollwer.Move(targetPos, _moveSpeed);

                float distance = (targetPos - transform.position).magnitude;
                isRun = distance > 0.1f;

                Vector3 playerLookDir = formation.transform.forward; // 플레이어가 바라보는 방향
                _Rotation.Rotate(playerLookDir, _rotateSpeed);
                break;

            case State.GO_TARGET:
                MoveTowards(Target.transform.position);

                isRun = true;

                if (Vector3.Distance(transform.position, Target.transform.position) < 0.5f)
                {
                    StartCarryingCoffin();
                }
                break;

            case State.GO_GOAL:
                MoveTowards(Area.transform.position);

                isRun = true;

                if (Vector3.Distance(transform.position, Area.transform.position) < 0.5f)
                {
                    DeliverCoffin();
                }
                break;

            case State.STAY:
                isRun = false;

                break;

        }
    }

    private void StartCarryingCoffin()
    {
        currentState = State.GO_GOAL;
    }

    private void DeliverCoffin()
    {
        Destroy(Target.gameObject); // 관 제거
        Debug.Log("관 배달 완료");
        Target = null;
        currentState = State.STAY;
    }

    private void MoveTowards(Vector3 target)
    {
        Vector3 dir = (target - transform.position).normalized;

        transform.position += dir * Time.fixedDeltaTime * 5f; // 속도 하드코딩 예시
    }

    public void AssignTarget(GameObject target, GameObject area)
    {
        currentState = State.GO_TARGET;
        Target = target;
        Area = area;
    }


    public void SetMiningSpeed(float value)
    {
        _miningSpeed += 1.0f;
    }

    // 아이템 먹을 시 스피드업
    public void SetMoveSpeed(float value)
    {
        _moveSpeed += value;
    }
}
