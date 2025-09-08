using UnityEngine;

public class Character : MonoBehaviour
{
    #region 속성값
    [SerializeField] float _moveSpeed = 10.0f;
    [SerializeField] float _rotateSpeed = 15.0f;
    private Collider col;
    private Rigidbody rb;
    private Animator animator;

    private Vector3 direction = Vector3.zero;
    
    public Vector3 Direction => direction;
    #endregion

    #region 캐릭터 내부 클래스
    private Movement _Movement;
    private Rotation _Rotation;
    private CharacterAnime _Anime;
    #endregion

    public float MoveSpeed { get { return _moveSpeed; } set { SetMoveSpeed(value); } }

    private void Awake()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

        _Movement = new Movement(rb);
        _Rotation = new Rotation(transform);
        _Anime = new CharacterAnime(animator);
    }


    private void Update()
    {
        // 키 입력받기
        direction.x = Input.GetAxisRaw("Horizontal");// 좌우
        direction.z = Input.GetAxisRaw("Vertical");  // 앞뒤

        direction.Normalize();

        _Anime.Running(direction);
    }

    private void FixedUpdate()
    {
        // 실제 이동
        _Movement.Move(direction, _moveSpeed);

        _Rotation.Rotate(direction, _rotateSpeed);
    }

    // 아이템 먹을 시 스피드업
    public void SetMoveSpeed(float value)
    {
        _moveSpeed += value;
    }
}
