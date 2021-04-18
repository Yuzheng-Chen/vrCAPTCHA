using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestureControl : MonoBehaviour
{
    public enum Gesture
    {
        strech,
        handsUp,
        handsLift
    }

    public Transform controllerLeft, controllerRight, headset;
    public Gesture currentGesture;
    public bool isCorrect;
    public float roundTime = 0.4f;
    public float wrongTime = 5f;
    public Image checkCircle;
    public TextMeshProUGUI checkText;
    public Animator animator;
    public float height = 1.7f;
    private float tempTime;
    private bool temp = true;
    private bool canTest = true;
    private float oneTime;

    private void Start()
    {
        Invoke("FailTest", wrongTime);
        height = GameHandler.height;

    }

    private void Update()
    {
        oneTime += Time.deltaTime;
        //checkText.text = (headset.position.z).ToString("f2");
        if (!canTest)
        {
            return;
        }
        SetAnimation();
        switch (currentGesture)
        {
            case Gesture.strech:
                CheckMotion(Vector3.Distance(controllerLeft.position, controllerRight.position) > height * 0.8f || Input.GetKey(KeyCode.Space));
                return;
            case Gesture.handsLift:
                CheckMotion(controllerLeft.position.z > headset.position.z + height * 0.3f
                    && controllerRight.position.z > headset.position.z + height * 0.3f || Input.GetKey(KeyCode.Space));
                return;
            case Gesture.handsUp:
                CheckMotion(controllerLeft.position.y > headset.position.y + height * 0.2f
                    && controllerRight.position.y > headset.position.y + height * 0.2f || Input.GetKey(KeyCode.Space));
                return;
            default:
                return;
        }
    }

    private void Timing()
    {
        tempTime += Time.deltaTime;
        checkCircle.fillAmount = tempTime / roundTime;
    }

    private void ClearTiming()
    {
        tempTime = 0;
        checkCircle.fillAmount = 0;
    }

    private void SetAnimation()
    {
        animator.SetInteger("gesture", (int)currentGesture);
    }

    private void CheckMotion(bool condition)
    {
        if (condition && temp)
        {
            Timing();
            if (tempTime > roundTime)
            {
                temp = false;
                isCorrect = true;
                checkText.text = "Correct";
                //correct
                FindObjectOfType<GameHandler>().record +=
                    FindObjectOfType<GameHandler>().currentCount + "," + true + "," + oneTime + "\n";
                if (FindObjectOfType<GameHandler>().currentCount > 28)
                {
                    //DataRecord.UpdateText();
                    SceneManager.LoadScene(4);
                    return;
                }
                FindObjectOfType<GameHandler>().currentCount++;
                FindObjectOfType<GameHandler>().totalCount++;
                CancelInvoke();
                Invoke("LoadNext", 2);
                ClearTiming();
            }
        }
        else
        {
            ClearTiming();
        }
    }

    private void FailTest()
    {
        checkText.color = Color.red;
        checkText.text = "Wrong";
        canTest = false;
        //wrong
        FindObjectOfType<GameHandler>().record +=
                    FindObjectOfType<GameHandler>().currentCount + "," + false + "," + oneTime + "\n";
        FindObjectOfType<GameHandler>().totalCount++;
        Invoke("Restart", 2);
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void LoadNext()
    {
        SceneManager.LoadScene(FindObjectOfType<GameHandler>().numbers[FindObjectOfType<GameHandler>().currentCount] + 1);
    }
}
