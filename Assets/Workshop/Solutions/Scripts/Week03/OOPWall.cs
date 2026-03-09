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
            if (hitBy is OOPPlayer)
            {
                OOPPlayer p = hitBy as OOPPlayer;
                p.TakeDamage(Damage);
                Debug.Log("Hit wall");
            }
        }
       
        

        private void SetUP()
        {
            IsIceWall = Random.Range(0, 100) < 20 ? true : false;
            if (IsIceWall)
            {
                GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
        public override void Hit(Identity hitBy)
        {
            if (IsIceWall)
            {
                mapGenerator.playerScript.TakeDamage(Damage, IsIceWall);
            }
            else
            {
                mapGenerator.playerScript.TakeDamage(Damage);
            }
            mapGenerator.mapdata[positionX, positionY] = null;
            Destroy(gameObject);
        }
    }
}