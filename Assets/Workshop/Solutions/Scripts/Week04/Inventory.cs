using System.Collections.Generic;
using UnityEngine;

namespace Solution {
    public class Inventory : MonoBehaviour
    {

        // เพิ่มไอเท็ม
        public void AddItem(ItemData item, int amount)
        {
            
        }

        // ลบไอเท็ม
        public void UseItem(ItemData item, int amount)
        {
            
        }
        public bool HasItem(ItemData item, int amount)
        {
            //2. ตรวจสอบว่ามีไอเท็มนี้ในคลังหรือไม่ และมีจำนวนเพียงพอหรือไม่
            return true;
        }
        // ตรวจสอบจำนวนไอเท็ม
        public int GetItemCount(ItemData item)
        {
           
            return 0;
        }

        // แสดงรายการทั้งหมดในคลัง
        public void PrintInventory()
        {
           
        }
    }
}

