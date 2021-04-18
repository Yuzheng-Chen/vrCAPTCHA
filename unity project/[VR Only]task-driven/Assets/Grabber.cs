using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private bool temp = false;
    private float oneTime;

    private void Update()
    {
        oneTime += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("grabable"))
        {
            if (OVRInput.Get(OVRInput.Axis1D.Any) != 0)
            {
                temp = true;
                other.transform.parent = transform;
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().freezeRotation = true;
            }
            else
            {
                if (temp)
                {
                    Invoke("FailTest", 4);
                }
                other.transform.parent = GameObject.Find("Intractable Cubes").transform;
                other.GetComponent<Rigidbody>().useGravity = true;
                other.GetComponent<Rigidbody>().freezeRotation = false;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("grabable"))
       {
            other.transform.parent = GameObject.Find("Intractable Cubes").transform;
            other.GetComponent<Rigidbody>().useGravity = true;
            if (temp)
            {
                Invoke("FailTest", 2);
            }
        }
    }

    
    private void FailTest()
    {
        GameObject.FindGameObjectWithTag("grabable").SetActive(false);
        FindObjectOfType<TextMesh>().text = "Wrong";
        FindObjectOfType<TextMesh>().color = Color.red;
        Invoke("Restart",2);
    }

    private void Restart()
    {
        FindObjectOfType<GameHandler>().record +=
    FindObjectOfType<GameHandler>().currentCount + "," + "false" + "," + oneTime + "\n";

        FindObjectOfType<GameHandler>().totalCount++;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void CancelWrongInvoke()
    {
        CancelInvoke();
    }
}
