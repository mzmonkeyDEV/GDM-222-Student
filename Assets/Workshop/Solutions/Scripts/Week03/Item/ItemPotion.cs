using UnityEngine;

namespace Solution
{
    [CreateAssetMenu(fileName = "PotionItem", menuName = "Items/PotionItem")]
    public class ItemPotion : ItemData
    {
        public int healPoint = 10;

        public override void Use(Identity identity)
        {
            Debug.Log($"��鹿پ�ѧ���Ե {healPoint} ���� {ItemName}");
            var player = identity as OOPPlayer;
            player.Heal(healPoint);
            Debug.Log("You got " + ItemName + " heal : " + healPoint);
        }
    }
}
