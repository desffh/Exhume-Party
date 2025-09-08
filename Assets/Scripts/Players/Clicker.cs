using UnityEngine;

public class Clicker : MonoBehaviour
{
    [SerializeField] Ray ray; // 광선에 대한 정보 
    [SerializeField] RaycastHit raycastHit;

    [SerializeField] LayerMask layerMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 발사할 레이, 출력용 매개변수로 값이 들어옴
            if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, layerMask))
            {
                Debug.Log(raycastHit.collider.transform.root.name);

                PetStateController.Instance.OnClickTarget(raycastHit.collider.gameObject);
            }
        }
    }
}
