using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Slider slider;
    public Transform image;
    public TMPro.TextMeshProUGUI checkText;
    public float sensity = 0.05f;
    private int initialAngle;
    private bool isCorrect;
    private bool temp = true;
    private float oneTime;

    private void Awake()
    {
        initialAngle = Random.Range(30, 330);
        checkText.gameObject.SetActive(false);
        image.rotation = Quaternion.Euler(image.rotation.eulerAngles.x, image.rotation.eulerAngles.y, initialAngle);
    }

    private void Update()
    {
        oneTime += Time.deltaTime;
        image.rotation = Quaternion.Euler(image.rotation.eulerAngles.x, image.rotation.eulerAngles.y, initialAngle + slider.value * 360);
        if (slider.value != 0 && !Input.GetMouseButton(0))
        {
            checkText.gameObject.SetActive(true);
            if (image.rotation.eulerAngles.z <= sensity || 360 - image.rotation.eulerAngles.z <= sensity)
            {
                checkText.text = "Correct";
                isCorrect = true;
                if (temp)
                {
                    Invoke("GoNext", 2);
                    temp = false;
                }

            }
            else
            {
                checkText.text = "Wrong";
                isCorrect = false;
                if (temp)
                {
                    Invoke("GoNext", 2);
                    temp = false;
                }

            }
        }
    }

    private void GoNext()
    {
        FindObjectOfType<GameHandler>().record +=
            FindObjectOfType<GameHandler>().currentCount + "," + isCorrect + "," + oneTime + "\n";

        FindObjectOfType<GameHandler>().totalCount++;
        if (isCorrect)
        {
            FindObjectOfType<GameHandler>().currentCount++;
            if (FindObjectOfType<GameHandler>().currentCount > 29)
            {
                //DataRecord.UpdateText();
                SceneManager.LoadScene(4);
                return;
            }
            else
            {
                SceneManager.LoadScene(FindObjectOfType<GameHandler>().numbers[FindObjectOfType<GameHandler>().currentCount] + 1);
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
