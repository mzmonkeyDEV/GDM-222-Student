using UnityEngine;

namespace Solution
{
    [CreateAssetMenu(fileName ="ItemPotion",menuName ="Item/ItemPotion")]
    public class ItemPotion : ItemData
    {
       public int healPoint= 10;

        public override void Use(Identity identity)
        {
            base.Use(identity);
            OOPPlayer p = identity as OOPPlayer;
            p.Heal(healPoint);
            Debug.Log("You got "+ ItemName);
        }
    }
}
