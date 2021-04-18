using System.IO;
using UnityEngine;

public class DataRecord : MonoBehaviour
{
    private static string path;
    void Awake()
    {
        string gameTime = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy_HH_mm_ss"); 
        path = Path.Combine(Application.persistentDataPath, "data_text-based_" + gameTime + ".csv");
        File.WriteAllText(path,string.Empty);
    }

    public static void UpdateText()
    {
        if (File.Exists(path))
        {
            using (TextWriter writer = File.AppendText(path))
            {
                writer.WriteLine("COUNT,ISCORRECT,TIME");
                writer.WriteLine(FindObjectOfType<GameController>().record);
                writer.WriteLine("Correct rate,"+ FindObjectOfType<GameController>().currectCount /(float)(FindObjectOfType<GameController>().totalCount-1));
                writer.Close();
            }
        }
    }
}
