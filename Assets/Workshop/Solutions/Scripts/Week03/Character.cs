using System;
using NUnit.Framework;
using UnityEngine;


namespace Solution
{
    public class Character : Identity
    {
        [Header("Character")]
        public int energy;
        public int maxEnergy;
        public int AttackPoint;

        protected bool isAlive;
        protected bool isFreeze;

        public SpriteRenderer spriteRenderer; // �ҡ SpriteRenderer �ͧ����Ф������� Inspector

        // �շ����Ҩ��� 3 �дѺ
        [Header("color energy")]
        public Color normalColor = Color.white;    // �ջ���
        public Color damagedColor1 = Color.yellow; // ���Ѻ������������дѺ 1 (�� HP ����� 66%)
        public Color damagedColor2 = Color.red;    // ���Ѻ������������дѺ 2 (�� HP ����� 33%)

        public override void SetUP()
        {
            base.SetUP();
            isAlive = true;
            isFreeze = false;
            Debug.Log("SetUP " + Name);
            spriteRenderer = GetComponent<SpriteRenderer>();
            energy = maxEnergy;

            UpdateSpriteColorBasedOnHealth(); // ������鹴��¡�õ�駤���յ����ѧ���Ե�Ѩ�غѹ
        }
        protected void GetRemainEnergy()
        {
            Debug.Log(name + " : " + energy);
        }

        public virtual void Move(Vector2 direction)
        {
            int toX =  (int)(positionX+ direction.x);
            int toY = (int)(positionY+ direction.y);
            if (isFreeze == true)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                isFreeze = false;
                return;
            }
            int toX = (int)(positionX + direction.x);
            int toY = (int)(positionY + direction.y);

            if (HasPlacement(toX, toY))
            {
                mapGenerator.GetMapData(toX,toY).Hit(this);
            }
            else
            {
                UpdatePosition(toX, toY);
                TakeDamage(1);
            }

            if (HasPlacement(toX,toY )) //|| HasPlacement(toX,toY) == null  
            {
                Debug.Log("Cant Move");
                Identity identity = mapGenerator.mapdata[toX,toY];
                identity.Hit(this);

            }
            else
            {
                mapGenerator.UpdatePositionIdentity(this,toX,toY);
              TakeDamage(1);
            }
        }
        // hasPlacement �׹��� true ����ա���ҧ������麹 map �����˹� x,y
        public void UpdatePostition(Vector2 direction)
        {
            
        }
        public bool HasPlacement(int x, int y)
        {
            var cell = mapGenerator.GetMapData(x,y);
            return cell != null;

        public virtual void UpdatePosition(int toX, int toY)
        {
            mapGenerator.mapdata[positionX, positionY] = null;
            positionX = toX;
            positionY = toY;
            transform.position = new Vector3(positionX, positionY, 0);
            mapGenerator.mapdata[positionX, positionY] = this;
        }

        // hasPlacement �׹��� true ����ա���ҧ������麹 map �����˹� x,y
        public bool HasPlacement(int x, int y)
        {
            var mapData = mapGenerator.GetMapData(x, y);
            return mapData != null;
        }
      

        public virtual void TakeDamage(int Damage)
        {
            energy -= Damage;
            Debug.Log(name + " Current Energy : " + energy);
            UpdateSpriteColorBasedOnHealth();
            CheckDead();
        }
        public virtual void TakeDamage(int Damage, bool freeze)
        {
            energy -= Damage;
            isFreeze = freeze;
            GetComponent<SpriteRenderer>().color = Color.blue;
            Debug.Log(name + " Current Energy : " + energy);
            Debug.Log("you is Freeze");
            UpdateSpriteColorBasedOnHealth();
            CheckDead();
        }


        public void Heal(int healPoint)
        {
            // energy += healPoint;
            // Debug.Log("Current Energy : " + energy);
            // �������ö���¡��ѧ��ѹ Heal �¡�˹���� Bonuse = false �� ���ͷ������ logic 㹡�� heal ������ѧ��ѹ Heal �ѹ�����������ͧ��¹���
            Heal(healPoint, false);
        }

        public void Heal(int healPoint, bool Bonuse)
        {
            energy += healPoint * (Bonuse ? 2 : 1);
            if (energy > maxEnergy)
            {
                energy = maxEnergy;
            }
            Debug.Log("Current Energy : " + energy);
        }

        protected virtual void CheckDead()
        {
            if (energy <= 0)
            {
                mapGenerator.mapdata[positionX, positionY] = null;
                Destroy(gameObject);
            }
        }
        protected void UpdateSpriteColorBasedOnHealth()
        {
            if (spriteRenderer == null) return;

            float healthPercentage = (float)energy / maxEnergy;

            if (healthPercentage > 0.66f) // �ҡ���� 66% (�� 67%-100%)
            {
                spriteRenderer.color = normalColor;
            }
            else if (healthPercentage > 0.33f) // �ҡ���� 33% ������Թ 66% (�� 34%-66%)
            {
                spriteRenderer.color = damagedColor1;
            }
            else // 33% ���͹��¡���
            {
                spriteRenderer.color = damagedColor2;
            }
            Debug.Log(name + " Health Percentage: " + (healthPercentage * 100) + "%");
        }
    }
}