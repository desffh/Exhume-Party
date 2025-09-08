using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    [Header("현재 내 뒤에 있는 해골 갯수")]
    [SerializeField] int PetCount;

    [SerializeField] List<GameObject> PetList = new List<GameObject>();

    public List<GameObject> _PetList => PetList; // 리스트 반환

    // 따라갈 플레이어 (프리팹x, 게임씬에 배치된 플레이어 할당)
    [SerializeField] GameObject Player;
    // 생성 될 해골 프리팹
    [SerializeField] GameObject PetPrefab;

    private Formation formation;

    private void Awake()
    {
        formation = Player.GetComponent<Formation>();
    }
    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            AddPet();
        }
    }

    public void AddPet()
    {
        Vector3 targetPos = formation.GetWorldTargetPos(PetCount);

        GameObject pet = Instantiate(PetPrefab, targetPos, Quaternion.identity);

        Skeleton pet_formation = pet.GetComponent<Skeleton>();

        pet_formation.Initialize(formation, PetCount);

        pet.transform.parent = transform;

        PetList.Add(pet);
        PetCount++;
    }

    public Skeleton RemovePet()
    {
        Skeleton pet = PetList[PetList.Count - 1].GetComponent<Skeleton>();
        PetList.RemoveAt(PetCount - 1);
        PetCount--;

        return pet;
    }
}
