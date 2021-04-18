using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Tester : MonoBehaviour
{
    private float oneTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("grabable"))
        {
            FindObjectOfType<Grabber>().CancelInvoke();
            FindObjectOfType<TextMesh>().text = "Correct";
            Invoke("LoadNext", 2);
        }
    }

    private void Update()
    {
        oneTime += Time.deltaTime;
    }

    private void LoadNext()
    {
        FindObjectOfType<GameHandler>().record +=
            FindObjectOfType<GameHandler>().currentCount + "," + "true" + "," + oneTime + "\n";

        FindObjectOfType<GameHandler>().totalCount++;
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
    }
}

