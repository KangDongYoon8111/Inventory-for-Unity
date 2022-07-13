using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item; // ������ ������ ����
    public Image itemIcon; // ǥ�õ� ������ �̹��� ����

    // ������ �̹����� �ʱ�ȭ�ϰ� Ȱ��ȭ��Ű�� �޼���
    public void UpdateSlotUI()
    {
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
    }

    // ������ ������ �ʱ�ȭ�ϰ� ��Ȱ��ȭ��Ű�� �޼���
    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }
}
