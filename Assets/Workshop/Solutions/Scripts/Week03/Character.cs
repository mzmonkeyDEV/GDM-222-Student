using UnityEngine;
using UnityEngine.XR;


namespace Solution
{
    public class Character : Identity
    {
        [Header("Character")]
        public int energy;
        public int AttackPoint;


        // Start is called before the first frame update
        protected void GetRemainEnergy()
        {

        }

        public virtual void Move(Vector2 direction)
        {
            positionX = (int)(positionX+ direction.x);
            positionY = (int)(positionY+ direction.y);

            transform.position = new Vector3(positionX,positionY,0);
           

        }
        // hasPlacement �׹��� true ����ա���ҧ������麹 map �����˹� x,y
        public bool HasPlacement(int x, int y)
        {
            return false;
        }
        

        public virtual void TakeDamage(int Damage)
        {
            energy -= Damage;
            CheckDead();
        }
        


        public void Heal(int healPoint)
        {
            energy += healPoint;
            Debug.Log("Current Energy : " + energy);
        }


        protected virtual void CheckDead()
        {
            if (energy <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}