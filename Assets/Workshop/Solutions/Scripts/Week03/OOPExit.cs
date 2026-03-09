using Assignment02.StudentSolution;
using UnityEngine;
using UnityEngine.U2D.IK;
using UnityEngine.SocialPlatforms.Impl;

namespace Solution
{
    public class OOPExit : Identity
    {
        public Canvas can;
        public override void Hit(Identity hitBy)
        {
            base.Hit(hitBy);
             if (hitBy is OOPPlayer)
            {
                mapGenerator.UpdatePositionIdentity(hitBy,positionX,positionY);
                can.gameObject.SetActive(true);
                hitBy.enabled = false;
            }
        public GameObject YouWin;
        public ItemData keyToExit;
        public int requiredKeyAmount;
        public Leaderboard leaderboard;
        public override void Hit(Identity hitBy)
        {
            if (hitBy is OOPPlayer) {
                OOPPlayer player = (OOPPlayer)hitBy;
                if (player.inventory.HasItem(keyToExit, requiredKeyAmount)) {
                    YouWin.SetActive(true);

                    player.inventory.UseItem(keyToExit, requiredKeyAmount);
                    player.UpdatePosition(this.positionX, this.positionY);
                    mapGenerator.playerScript.enabled = false;

                    int scoreReceived = CalculateScore(player);
                    string playerName = player.Name;

                    PlayerScore data =  new PlayerScore(playerName, scoreReceived);
                    leaderboard.RecordScore(data);
                    leaderboard.ShowleaderBoard();
                    JsonSaveLoadSystem.SaveGame(data);
                    Debug.Log("You win");
                }
            }
            
        }

        int CalculateScore(OOPPlayer player)
        {
            int score = (int)((player.energy * 100) / Time.time);
            return score;
        }
    }
}