using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public PhotoControl[] allPhotos;
    [HideInInspector]
    public int[] photoNumbers;
    [HideInInspector]
    public int[] cateCount;

    public TextMeshProUGUI checkText;


    public int correctCount, wrongCount;
    public PhotoControl.PhotoCategory sceneCate;


    private void Awake()
    {
        cateCount = new int[4];       
        SetRandomPhotos();
    }

    private void Start()
    {
        checkText.text = "Please select all pictures which include " + sceneCate;
    }

    public void SetRandomPhotos()
    {
        FindObjectOfType<GameHandler>().SetRandomNumbers(out photoNumbers, allPhotos.Length, 1);
    }

    public void Verify()
    {
        if (correctCount == cateCount[(int)sceneCate] && wrongCount == 0)
        {
            checkText.text = "Correct";
            FindObjectOfType<GameHandler>().currentCount++;
            Invoke("LoadNext", 2);
            return;
        }

        checkText.text = "Wrong";
        Invoke("Restart", 2);
        //wrong
        return;
    }

    private void LoadNext()
    {
        if (FindObjectOfType<GameHandler>().currentCount > 29)
        {
            //DataRecord.UpdateText();
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(FindObjectOfType<GameHandler>().numbers[FindObjectOfType<GameHandler>().currentCount] + 1);
        }
        
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
