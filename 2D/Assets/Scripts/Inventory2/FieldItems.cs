using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    // ���� ����� Item ����
    public Item m_item;
    // ���� ����� Image ����
    public SpriteRenderer image;

    // ������ ������ ���� �޼���
    public void SetItem(Item item)
    {
        m_item.itemName = item.itemName;
        m_item.itemImage = item.itemImage;
        m_item.itemType = item.itemType;

        image.sprite = m_item.itemImage;
    }

    // ������ ȹ�� �� ����� �޼���
    public Item GetItem()
    {
        return m_item;
    }

    // ������ ȹ�� �� ����� �޼ҵ�
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
