using UnityEngine;

namespace Solution
{

    public class OOPItem : Identity
    {
        public ItemData itemData;
        public override void Hit(Identity hitBy)
        {
            base.Hit(hitBy);
            if(hitBy is Character)
            {
                mapGenerator.UpdatePositionIdenity
                (hitBy,positionX,positionY);
                itemData.Use(hitBy);
                Destroy(gameObject);
            }
        }
       
    }
}