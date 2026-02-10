using UnityEngine;

namespace Solution
{
    public class OOPExit : Identity
    {
        public GameObject YouWin;

        public override void Hit(Identity hitBy)
        {
            mapGenerator.playerScript.enabled = false;
            YouWin.SetActive(true);
            Debug.Log("You win");
        }
    }
}