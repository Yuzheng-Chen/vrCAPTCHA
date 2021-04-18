using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TMP_InputField textField;
    public string[] inputText;
    public Sprite[] textImage;
    public TMPro.TextMeshProUGUI checkText;
    public UnityEngine.UI.Image image;
    public static GameController Instance;
    [HideInInspector]
    public int number;
    public string record;
    private bool temp = true;
    private bool temp2 = true;
    private bool isCorrect;
    private int[] numbers;
    public int currectCount;
    public int totalCount;
    private float oneTime;
    private bool start;

    private void Awake()
    {
        SetRandomNumbers(out numbers, inputText.Length);
        ResetGame();
    }
    
    public void StartGame()
    {
        start = true;
    }

    private void Update()
    {
        if (start)
        {
            oneTime+=Time.deltaTime;
        }
        if (temp && Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            CheckText();
            temp = false;
        }
    }

    public void CheckText()
    {  
        checkText.gameObject.SetActive(true);
        if (textField.text.ToUpper() == inputText[number].ToUpper())
        {
            isCorrect = true;
            checkText.text = "Correct";
            InvokeNext(2);
            
        }
        else
        {
            isCorrect = false;
            checkText.text = "Wrong";
            InvokeNext(2);            
        }
        textField.text = string.Empty;
        Debug.Log("Is Correct: " + isCorrect);
    }

    private void InvokeNext(float time)
    {
        if (temp)
        {
            Invoke("ResetGame", time);
            temp = false;
        }
        else
        {
            checkText.color = Color.red;
            checkText.text = "Do not submit repeatedly!";
        }
    }

    private void ResetGame()
    {
        temp = true;
        if (isCorrect)
            currectCount++;
        if (currectCount >= inputText.Length)
        {
            totalCount++;
            checkText.color = Color.red;
            checkText.text = "Finished!";
            record += (totalCount - 1).ToString() + "," + isCorrect + "," + oneTime.ToString() + "\n";
            //DataRecord.UpdateText();
            Time.timeScale = 0;
            return;
        }
        else
            temp = true;
        totalCount++;
        checkText.color = Color.white;
        checkText.gameObject.SetActive(false);
        if (isCorrect)           
            number = numbers[currectCount];
        else
            number = numbers[currectCount];
        image.sprite = textImage[number];
        checkText.text = "Check";
        Debug.Log("Currect Count: " + currectCount);
        if (totalCount <= inputText.Length-1)
        {
            record += (totalCount-1).ToString() + "," + isCorrect + "," + oneTime.ToString() + "\n";
            oneTime = 0;
        }
    }

    private void SetRandomNumbers(out int[] numbers, int count)
    {
        numbers = new int[count];
        int[] tempNumbers = new int[count];
        for (int i = 0; i < count; i++)
        {
            tempNumbers[i] = i;
        }
        for (int i = 0; i < count; i++)
        {
            int tempNumber = Random.Range(i, count);
            numbers[i] = tempNumbers[tempNumber];
            int tempNumber2 = tempNumbers[tempNumber];
            tempNumbers[tempNumber] = tempNumbers[i];
            tempNumbers[i] = tempNumber2;
            Debug.Log(numbers[i]);
        }
    }

}
