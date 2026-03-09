using System.IO;
using Solution;
using UnityEngine;
namespace Solution
{
    public class JsonSaveLoadSystem : MonoBehaviour
    {
        private static string saveFilePath = Application.persistentDataPath + "/savefile.json";

        public static void SaveGame(PlayerScore data)
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(saveFilePath,json);
            Debug.Log(saveFilePath);
        }

        public static PlayerScore LoadGame()
        {
            if (File.Exists(saveFilePath))
            {
                Debug.Log("game loading...");
                string json = File.ReadAllText(saveFilePath);
                PlayerScore data = JsonUtility.FromJson<PlayerScore>(json);
                return data;
            }
            else
            {
                return null;
            }
        }
    }
}