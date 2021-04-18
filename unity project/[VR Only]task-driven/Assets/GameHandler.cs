using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler Instance;

    public int[] numbers;
    public int currentCount;
    public int totalCount;
    public string record;
    public static int tempNum;


    private void Awake()
    {
        tempNum = Random.Range(0, 2);
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

        SetRandomNumbers(out numbers, 3, 10);
        //
    }

    public void LoadNext()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(numbers[currentCount] + 1);
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
