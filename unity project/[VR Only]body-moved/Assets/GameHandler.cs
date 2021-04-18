using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance;

    public int[] numbers;
    public int currentCount;
    public int totalCount;
    public string record;
    public static float height = 1.7f;
    public TextMeshProUGUI YourHeight;

    private void Awake()
    {
        YourHeight.text = "Your height is "+height+"m";
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        if (currentCount > 0)
        {
            return;
        }

        SetRandomNumbers(out numbers, 3, 11);
        //
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (OVRInput.GetDown(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                height -= 0.02f;
                YourHeight.text = "Your height is " + height + "m";
            }
            if (OVRInput.GetDown(OVRInput.Button.Two) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                height += 0.02f;
                YourHeight.text = "Your height is " + height + "m";
            }
        }
    }

    public void LoadNext()
    {
        SceneManager.LoadScene(numbers[currentCount] + 1);
    }

    public void SetRandomNumbers(out int[] numbers, int count, int repeat)
    {
        numbers = new int[count * repeat];

        for (int j = 0; j < repeat; j++)
        {
            int[] tempNumbers = new int[count];
            for (int i = 0; i < count; i++)
            {
                tempNumbers[i] = i;
            }
            for (int i = 0; i < count; i++)
            {
                int tempNumber = Random.Range(i, count);
                numbers[i + j * count] = tempNumbers[tempNumber];
                int tempNumber2 = tempNumbers[tempNumber];
                tempNumbers[tempNumber] = tempNumbers[i];
                tempNumbers[i] = tempNumber2;
                Debug.Log(numbers[i + j * count]);
            }
        }
    }
}
