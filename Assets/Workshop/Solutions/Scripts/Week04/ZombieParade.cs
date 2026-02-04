using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solution
{
    public class ZombieParade : OOPEnemy
    {
        // �� LinkedList 㹡�èѴ�����ǹ�ͧ�����ͻ���Է���Ҿ㹡������/ź
        // �� LinkedList 㹡�èѴ�����ǹ�ͧ�����ͻ���Է���Ҿ㹡������/ź
        private LinkedList<GameObject> Parade = new LinkedList<GameObject>();
        public int SizeParade = 3;
        int timer = 0;
        public GameObject[] bodyPrefab; // Prefab �ͧ��ǹ�ӵ�ǧ�
        public float moveInterval = 0.5f; // ��ǧ����㹡������͹��� (0.5 �Թҷ�)

        private Vector3 moveDirection;

        public void Start()
        {
            moveDirection = Vector3.up;
            // ����� Coroutine ����Ѻ�������͹���
            positionX = (int)transform.position.x;
            positionY = (int)transform.position.y;
            StartCoroutine(MoveParade());
        }
        private Vector3 RandomizeDirection()
        {
            List<Vector3> possibleDirections = new List<Vector3>
            {
                Vector3.up,
                Vector3.down,
                Vector3.left,
                Vector3.right
            };

            return possibleDirections[Random.Range(0, possibleDirections.Count)];
        }
        // Coroutine ����Ѻ�������͹�����Ъ�ͧ
        IEnumerator MoveParade()
        {      
            yield return null;
     
            //0. ���ҧ��ǧ�
            while (isAlive)
            {
               
                yield return new WaitForSeconds(moveInterval);
            }
        }
        private bool IsCollision(int x, int y)
        {
            // 4. ��Ǩ�ͺ��觡մ��ҧ
            if (HasPlacement(x, y))
            {
                return true;
            }
            return false;
        }
        
        // �ѧ��ѹ����Ѻ������ǹ�ͧ�� (Grow)
        private void Grow()
        {
           GameObject newPart = Instantiate(bodyPrefab[0]);

           GameObject lastPart = Parade.Last.Value;

           newPart.transform.position = lastPart.transform.position;

           Parade.AddLast(newPart);
        }

    }
}
