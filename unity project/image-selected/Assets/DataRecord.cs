using System.IO;
using UnityEngine;

public class DataRecord : MonoBehaviour
{
    private static string path;
    void Awake()
    {
        string gameTime = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy_HH_mm_ss");
        path = Path.Combine(Application.persistentDataPath, "data_image-selected_" + gameTime + ".csv");
        File.WriteAllText(path, string.Empty);
    }

    public static void UpdateText()
    {
        if (File.Exists(path))
        {
            using (TextWriter writer = File.CreateText(path))
            {
                writer.WriteLine("COUNT,ISCORRECT,TIME");
                writer.WriteLine(FindObjectOfType<GameHandler>().record);
                writer.WriteLine("Correct rate," + FindObjectOfType<GameHandler>().currentCount / (float)(FindObjectOfType<GameHandler>().totalCount));
                writer.Close();
            }
        }
    }
}
