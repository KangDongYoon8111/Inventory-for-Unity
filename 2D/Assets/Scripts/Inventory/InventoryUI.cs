using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // Inventory 컴포넌트가 담길 변수
    private Inventory inventory;

    // Inventory UI 오브젝트가 담길 변수
    public GameObject inventoryPanel;

    // Inventory UI 오브젝트의 Open&Close 상태를 표현할 bool형 변수
    private bool activeInventory = false;

    // 사용자 인벤토리의 슬롯을 담을 배열선언
    public Slot[] slots;
    // slot들을 품고있는 부모 오브젝트 지정 변수
    public Transform slotHolder;

    void Start()
    {
        // slotHolder의 자식 오브젝트들에서 Slot 컴포넌트를 한번에 배열로 가져오기
        slots = GetComponentsInChildren<Slot>();
        // inventoryPanel의 활성화 상태를 activaInventory 값(비활성화)으로 바꿔주세요.
        inventoryPanel.SetActive(activeInventory);

        // inventory 변수 초기화
        inventory = Inventory.instance;
        // Inventory>onSlotCountChange에 SlotChange 메서드 등록(구독)
        inventory.onSlotCountChange += SlotChange;
        // Inventory>onChangeItem에 RedrawSlotUI 메서드 등록(구독)
        inventory.onChangeItem += RedrawSlotUI;
    }

    // inventory의 SlotCount의 값만큼 Slot을 활성화시키는 메서드
    private void SlotChange(int value)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponent<Button>().interactable = i < inventory.SlotCount ? true : false;
        }
    }

    // inventory의 SlotCount의 값을 증가시키는 메서드
    public void AddSlot()
    {
        inventory.SlotCount++;
    }

    // 반복문을 통해 슬롯들을 초기화하고 items의 개수만큼 slot을 채워넣는 메서드
    private void RedrawSlotUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }

        for(int i = 0; i < inventory.items.Count; i++)
        {
            slots[i].item = inventory.items[i];
            slots[i].UpdateSlotUI();
        }
    }

    void Update()
    {
        // 만약에 사용자가 'I'키를 눌렀다면,
        if (Input.GetKeyDown(KeyCode.I))
        {
            // 현재 activeInventory의 반대상태(Not)를 activeInventory에 담아주세요.
            activeInventory = !activeInventory;
            // inventoryPanel의 활성화 상태를 activaInventory 값으로 바꿔주세요.
            inventoryPanel.SetActive(activeInventory);
        }
    }
}