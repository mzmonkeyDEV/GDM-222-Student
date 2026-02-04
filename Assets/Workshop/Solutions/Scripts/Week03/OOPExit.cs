using UnityEngine;

namespace Solution
{
    public class OOPExit : Identity
    {
       public GameObject WinUi;

        public override void Hit(Identity hitBy)
        {
            base.Hit(hitBy);
            if(hitBy is OOPPlayer)
            {
                WinUi.gameObject.SetActive(true);
                mapGenerator.UpdatePositionIdenity(hitBy,positionX,positionY);
                hitBy.enabled = false;
            }

        }
    }
}