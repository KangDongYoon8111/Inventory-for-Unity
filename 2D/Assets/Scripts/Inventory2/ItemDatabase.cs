using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;

    public List<Item> itemDB = new List<Item>();

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    // FieldItem 프리팹을 담을 변수
    public GameObject fieldItemPrefab;
    // 생성할 위치를 담을 배열
    public Vector3[] pos;

    private void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            // FieldItem 프리팹을 이용하여 복제본 생성, Item 오브젝트에 초기화
            GameObject item = Instantiate(fieldItemPrefab, pos[i], Quaternion.identity);

            // 복제된 item에서 SetItem메서드를 실행하여,
            // itemDB의 값 중 하나로 랜덤하게 아이템 데이터 설정
            item.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0, 3)]);
        }
    }
}
