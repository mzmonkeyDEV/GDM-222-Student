using UnityEngine;

namespace Solution
{

    public class OOPWall : Identity
    {
        public int Damage;
        public bool IsIceWall;

        public override void Hit(Identity hitBy)
        {
            base.Hit(hitBy);
            if(hitBy is OOPPlayer)
            {
                OOPPlayer p = hitBy as OOPPlayer;
                p.TakeDamage(Damage);
                Debug.Log("Hit wall");
            }
        }
        
    }
}