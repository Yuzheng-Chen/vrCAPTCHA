using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Slider sliderBackground;
    public Slider slider;
    public TMPro.TextMeshProUGUI checkText;
    public GameObject imageInside;
    public GameObject imageInsideBG;
    public GameObject imageBG;
    Transform trans;
    [Range(0, 1)]
    public float sensitivity = 0.05f;
    private bool isCorrect;
    private bool temp = true;
    private float oneTime;

    private float randomValue;
    private void Awake()
    {
        checkText.gameObject.SetActive(false);
        randomValue = Random.Range(0.3f, 1f);
        sliderBackground.value = randomValue;
        trans = imageInsideBG.transform.parent;
        imageInsideBG.transform.parent = transform;
        imageInsideBG.transform.position = imageBG.transform.position;

    }

    private void Start()
    {
        imageInsideBG.transform.parent = trans;
        imageInside.transform.localPosition = imageInsideBG.transform.localPosition;
    }

    private void Update()
    {
        oneTime += Time.deltaTime;
        if (slider.value != 0 && !Input.GetMouseButton(0))
        {
            checkText.gameObject.SetActive(true);
            if (Mathf.Abs(slider.value - randomValue) <= sensitivity)
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
