using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 pos = new Vector3(0, 8, -7);    

    private void Update()
    {
        // 카메라가 플레이어에서 떨어진 만큼 더한 값에 카메라가 위치한다.
        this.gameObject.transform.position = player.transform.position + pos;
    }
}
