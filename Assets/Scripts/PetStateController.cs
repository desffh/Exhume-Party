using UnityEngine;

public class PetStateController : Singleton<PetStateController>
{
    [SerializeField] PetManager manager;

    [SerializeField] MyArea area;

    public void OnClickTarget(GameObject target)
    {
        if(manager._PetList.Count > 0)
        {
            Skeleton sk = manager.RemovePet();

            if (target != null)
            {
                sk.GetComponent<Skeleton>().AssignTarget(target, area.gameObject);

                target.GetComponent<Coffin>().AssignTarget(area.gameObject);
            }
        }
    }
}
