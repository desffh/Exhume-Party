using UnityEngine;

public class MyArea : MonoBehaviour
{
    private Collider col;


    private void Awake()
    {
        col = GetComponent<Collider>();
    }
}
