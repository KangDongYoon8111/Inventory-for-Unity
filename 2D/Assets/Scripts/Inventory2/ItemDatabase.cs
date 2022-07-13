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

    // FieldItem �������� ���� ����
    public GameObject fieldItemPrefab;
    // ������ ��ġ�� ���� �迭
    public Vector3[] pos;

    private void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            // FieldItem �������� �̿��Ͽ� ������ ����, Item ������Ʈ�� �ʱ�ȭ
            GameObject item = Instantiate(fieldItemPrefab, pos[i], Quaternion.identity);

            // ������ item���� SetItem�޼��带 �����Ͽ�,
            // itemDB�� �� �� �ϳ��� �����ϰ� ������ ������ ����
            item.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0, 3)]);
        }
    }
}
