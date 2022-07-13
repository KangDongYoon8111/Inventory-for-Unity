using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // �̱������� ����
    // 1. ������ �ս��� ����
    // 2. �� �ϳ��� ����
    public static Inventory instance;

    // slotCount�� ��ȭ�� �˷��� ��������Ʈ(�븮��) ����
    public delegate void OnSlotCountChange(int value);
    // slotCount�� ��ȭ�� �˷��� ��������Ʈ(�븮��) �ν��Ͻ�ȭ
    public OnSlotCountChange onSlotCountChange;

    // ������ �߰��� ����UI���� �˷��� ��������Ʈ(�븮��) ����
    public delegate void OnChangeItem();
    // ������ �߰��� ����UI���� �˷��� ��������Ʈ(�븮��) �ν��Ͻ�ȭ
    public OnChangeItem onChangeItem;

    // Slot�� ������ ������ ����
    private int slotCount;
    // slotCount ĸ��ȭ ������Ƽ
    public int SlotCount
    {
        // �ܺο��� ���� �о�� ��� slotCount�� ���� �Ѱ��ش�.
        get => slotCount;
        // �ܺο��� ���� ������ ���
        set
        {
            // slotCount�� �Է°��� �����Ѵ�.
            slotCount = value;
            // slotCount�� ��ȭ�� �˷��� ��������Ʈ(�븮��)�� ȣ��
            onSlotCountChange.Invoke(slotCount);
        }
    }

    // ȹ���� �������� ���� List
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        // ���࿡ instance�� ������� �ʴٸ�,
        if(instance != null)
        {
            // ���� ������Ʈ�� ������
            Destroy(gameObject);
            // �Ʒ��� �� �̻� �������� ���� ���ư�
            return;
        }

        // instance�� ���� �� �ڽ��� �־���
        instance = this;
    }

    void Start()
    {
        // SlotCount�� 4�� �ʱ�ȭ
        SlotCount = 4;
    }

    // items ����Ʈ�� �������� �߰��� �� �ִ� �޼���
    public bool AddItem(Item item)
    {
        // ���࿡ items(����Ʈ)�� ������
        // slotCount(���� Ȱ�� ����)���� �۴ٸ�,
        if(items.Count < SlotCount)
        {
            // items ����Ʈ�� ������ �߰�
            items.Add(item);
            // ���࿡ onChangItem�� ������� �ʴٸ�,
            // onChangeItem ȣ��
            if (onChangeItem != null) onChangeItem.Invoke();

            return true; // ������ �߰� ����
        }

        return false; // ������ �߰� ����
    }

    // �÷��̾�� �ʵ� ������ �浹ó��
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger!!!");
        // ���࿡ �浹�� ����� �±װ� FieldItem�� ���ٸ�,
        if (other.CompareTag("FieldItem"))
        {
            // �浹�� �����ۿ��� FieldItems������Ʈ�� �����(��������)
            // 1. FieldItems���� �������� ����(������)�� ����ִ�.
            FieldItems fieldItems = other.GetComponent<FieldItems>();
            // ���࿡ AddItem �޼��忡 �������� ������ ������ ������ �߰���
            // �����Ѵٸ�, �浹�� �������� ��������
            if (AddItem(fieldItems.GetItem())) fieldItems.DestroyItem();
        }
    }

    void Update()
    {
        
    }
}
