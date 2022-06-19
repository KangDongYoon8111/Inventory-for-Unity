using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item; // 아이템 데이터 변수
    public Image itemIcon; // 표시될 아이템 이미지 변수

    // 슬롯의 이미지를 초기화하고 활성화시키는 메서드
    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }

    // 슬롯을 정보를 초기화하고 비활성화시키는 메서드
    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }
}
