using UnityEngine;

public class FieldItems : MonoBehaviour
{
    public Item m_item; // 실제 적용할 Item 적용
    public SpriteRenderer image; // 실제 적용할 Image 적용

    // 아이템 데이터 생성 메서드
    public void SetItem(Item item)
    {
        m_item.itemName = item.itemName;
        m_item.itemImage = item.itemImage;
        m_item.itemType = item.itemType;

        image.sprite = m_item.itemImage;
    }

    // 아이템 획득 시 실행될 메서드
    public Item GetItem()
    {
        return m_item;
    }

    // 아이템 획득 시 실행될 메서드
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
