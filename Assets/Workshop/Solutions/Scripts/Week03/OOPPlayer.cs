using UnityEngine;

namespace Solution
{

    public class OOPPlayer : Character
    {
        public Inventory inventory;
        public int Gold;
        public ItemData KeyItemFireStorm;
        public override void SetUP()
        {
            PrintInfo();
            GetRemainEnergy();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Move(Vector2.up);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Move(Vector2.down);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Move(Vector2.left);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Move(Vector2.right);
            }
            if (Input.GetKeyDown(KeyCode.E)) {
                UseFireStorm();
            }
        }

        public void Attack(OOPEnemy _enemy)
        {
            _enemy.energy -= AttackPoint;
            Debug.Log(_enemy.name + " is energy " + _enemy.energy);
        }

        protected override void CheckDead()
        {
            base.CheckDead();
            if (energy <= 0)
            {
                Debug.Log("Player is Dead");
            }
        }
        public void UseFireStorm()
        {
            if (inventory.HasItem(KeyItemFireStorm, 1))
            {
                inventory.UseItem(KeyItemFireStorm, 1);
                OOPEnemy[] enemies = UtilitySortEnemies.SortEnemiesByRemainningEnergy1(mapGenerator);
                int count = 3;
                if (count > enemies.Length)
                {
                    count = enemies.Length;
                }
                for (int i = 0; i < count; i++)
                {
                    enemies[i].TakeDamage(10);
                }
            }
            else
            {
                Debug.Log("No FireStorm in inventory");
            }
        }
    }

}