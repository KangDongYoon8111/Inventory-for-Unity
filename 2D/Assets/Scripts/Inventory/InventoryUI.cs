using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
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

        inventory = Inventory.instance;
        inventory.onSlotCountChange += SlotChange;
    }

    private void SlotChange(int value)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].GetComponent<Button>().interactable = i < inventory.SlotCount ? true : false;
        }
    }

    public void AddSlot(){
        inventory.SlotCount++;
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