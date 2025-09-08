using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RowDefine
{
    public int count;
}

public class Formation : MonoBehaviour
{
    [Header("Formation of Sckeleton Location")]
 
    [SerializeField] float XSpacing = 1.5f;     // 좌우 간격
    [SerializeField] float ZSpacing = 1.0f;     // 앞뒤 간격
    [SerializeField] float BackOffSet = 1.0f;   // 캐릭터 바로 뒤 간격

    [SerializeField] List<RowDefine> rows = new List<RowDefine>(5);


    // 인덱스의 월드 위치를 반환
    public Vector3 GetWorldTargetPos(int index)
    {
        int row = 0; // 몇번째 행인지

        int consumed = 0; // 몇마리의 해골이 배치되었는지 (누적합)
        
        for (row = 0; row < rows.Count; row++)
        {
            int c = rows[row].count;
            if (index < consumed + c) break;
            consumed += c;
        }

        // 범위를 넘으면 마지막 줄의 마지막 칸으로
        if (row >= rows.Count)
            row = rows.Count - 1;

        RowDefine define = rows[row]; // 배치될 행
        int col = Mathf.Clamp(index - consumed, 0, define.count - 1); // 배치될 칸(열)

        // X: 가운데 정렬 (줄 개수에 따라 좌우로 벌어지게)
        float xStart = -((define.count - 1) * 0.5f) * XSpacing; // 배치 시작 위치 (왼쪽 끝)
        float xLocal = xStart + col * XSpacing; // 실제 배치되는 위치 

        // Z: 배치될 행에 따라 플레이어 뒤로 이동될 거리
        float zLocal = -(BackOffSet + row * ZSpacing);

        // 로컬 -> 월드
        return transform.position + transform.right * xLocal + transform.forward * zLocal;
    }
}
