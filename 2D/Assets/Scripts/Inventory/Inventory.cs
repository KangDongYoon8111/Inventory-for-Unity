using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // 싱글톤패턴 적용
    // 1. 누구나 손쉽게 접근
    // 2. 단 하나만 존재
    public static Inventory instance;

    // slotCount의 변화를 알려줄 델리게이트(대리자) 정의
    public delegate void OnSlotCountChange(int value);
    // slotCount의 변화를 알려줄 델리게이트(대리자) 인스턴스화
    public OnSlotCountChange onSlotCountChange;

    // Slot의 갯수를 지정할 변수
    private int slotCount;
    // slotCount 캡슐화 프로퍼티
    public int SlotCount
    {
        // 외부에서 값을 읽어올 경우 slotCount의 값을 넘겨준다.
        get => slotCount;
        // 외부에서 값을 적용할 경우
        set
        {
            // slotCount에 입력값을 적용한다.
            slotCount = value;
            // slotCount의 변화를 알려줄 델리게이트(대리자)를 호출
            onSlotCountChange.Invoke(slotCount);
        }
    }

    private void Awake()
    {
        // 만약에 instance가 비어있지 않다면,
        if (instance != null)
        {
            // 현재 오브젝트를 지워줘
            Destroy(gameObject);
            // 아래로 더 이상 내려가지 말고 돌아가
            return;
        }

        // instance에 현재 내 자신을 넣어줘
        instance = this;
    }

    void Start()
    {
        // SlotCount를 4로 초기화
        SlotCount = 4;
    }

    void Update()
    {

    }
}