using UnityEngine;

// ������ Ÿ�� ������(����)
public enum ItemType
{
    Equipment, // ���
    Consumables, // �Ҹ�ǰ
    Etc // ��Ÿ
}

// Serializable : ����ڰ� ������ Ŭ���� �Ǵ� ����ü�� ������
// �ν����Ϳ� ������� �ʽ��ϴ�. ������, System���� �����ϴ�
// Serializable �Ӽ��� �����ϸ� �ν����Ϳ� �����ų �� �ֽ��ϴ�.
[System.Serializable]
public class Item
{
    public ItemType itemType; // ������ Ÿ��
    public string itemName; // ������ �̸�
    public Sprite itemImage; // ������ �̹���

    // ������ ��� �޼��� : ��� ���� ���θ� ��ȯ
    public bool Use()
    {
        return false;
    }
}
