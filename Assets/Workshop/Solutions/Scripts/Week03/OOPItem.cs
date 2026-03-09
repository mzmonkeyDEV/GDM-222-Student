using Assignment02.StudentSolution;
using UnityEngine;
using UnityEngine.UIElements;

namespace Solution
{

    public class OOPItem : Identity
    {
        public ItemData ItemData;
        public override void Hit(Identity hitBy)
        {
            base.Hit(hitBy);
            if (hitBy is Character)
            {
                mapGenerator.UpdatePositionIdentity(hitBy,positionX,positionY);
                ItemData.Use(hitBy);
                Destroy(gameObject);
            }
        }
       
        SpriteRenderer spriteRenderer;
        public ItemData itemData;

        public override void SetUP()
        {
            base.SetUP();
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = itemData.icon;
            
        }
        public override void Hit(Identity hitBy)
        {
            itemData.Use(hitBy);
            if (hitBy is Character) {
                Character character = (Character)hitBy;
                character.UpdatePosition(positionX, positionY);
            }
            

            Destroy(this.gameObject);
        }
    }
}