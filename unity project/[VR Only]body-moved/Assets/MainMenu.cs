using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.Any) != 0)
        {
            SceneManager.LoadScene(FindObjectOfType<GameHandler>().numbers[0] +1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKey(KeyCode.B))
        {
            SceneManager.LoadScene(2);
        }
        if (Input.GetKey(KeyCode.C))
        {
            SceneManager.LoadScene(3);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(FindObjectOfType<GameHandler>().numbers[0] + 1);
        }
    }
}
