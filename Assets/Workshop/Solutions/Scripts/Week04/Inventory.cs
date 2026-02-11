using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Solution {
    public class Inventory : MonoBehaviour
    {
        public Dictionary<ItemData,int> inventory = new Dictionary<ItemData, int>();

        // ���������
        public void AddItem(ItemData item, int amount)
        {
            if (inventory.ContainsKey(item))
            {
                inventory[item] += amount;
            }
            else
            {
                inventory.Add(item,amount);
            }
            Debug.Log($"Added {amount} {item.ItemName} Total : {inventory[item]}");
        }

        // ź�����
        public void UseItem(ItemData item, int amount)
        {
            if (HasItem(item,amount))
            {
                inventory[item] -= amount;
                if(inventory[item] <= 0)
                {
                    inventory.Remove(item);
                    Debug.Log($"Removed {item.ItemName} from inventory");
                }
            }
            else
            {
                Debug.Log("Cannot Remove" + item.ItemName);
            }
            
        }
        public bool HasItem(ItemData item, int amount)
        {
            //2. ��Ǩ�ͺ�������������㹤�ѧ������� ����ըӹǹ��§���������
            return inventory.ContainsKey(item) && inventory[item] >= amount;
        }
        // ��Ǩ�ͺ�ӹǹ�����
        public int GetItemCount(ItemData item)
        {
           
            return 0;
        }

        // �ʴ���¡�÷�����㹤�ѧ
        public void PrintInventory()
        {
           
        }
    }
}

