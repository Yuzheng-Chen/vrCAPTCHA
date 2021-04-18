using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTransform : MonoBehaviour
{
    public bool grabble;
    private bool grabbleIsRight;
    public float rightPosX_Min, rightPosX_Max, leftPosX_Min, leftPosX_Max;
    public float rightPosZ_Min, rightPosZ_Max, leftPosZ_Min, leftPosZ_Max;

    private void Start()
    {
        Vector3 tempRotation = new Vector3(transform.rotation.eulerAngles.x, Random.Range(0, 360), transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(tempRotation);

        Debug.Log("?????"+GameHandler.tempNum);
        if (GameHandler.tempNum == 0)
        {
            grabbleIsRight = true;
        }
        if (grabble)
        {
            if (grabbleIsRight)
            {
                float rightPosX = Random.Range(rightPosX_Min, rightPosX_Max);
                float rightPosZ = Random.Range(rightPosZ_Min, rightPosZ_Max);
                transform.position = new Vector3(rightPosX, transform.position.y, rightPosZ);
            }
            else
            {
                float leftPosX = Random.Range(leftPosX_Min, leftPosX_Max);
                float leftPosZ = Random.Range(leftPosZ_Min, leftPosZ_Max);
                transform.position = new Vector3(leftPosX, transform.position.y, leftPosZ);
            }
        }
        else
        {
            if (grabbleIsRight)
            {
                float leftPosX = Random.Range(leftPosX_Min, leftPosX_Max);
                float leftPosZ = Random.Range(leftPosZ_Min, leftPosZ_Max);
                transform.position = new Vector3(leftPosX, transform.position.y, leftPosZ);
            }
            else
            {
                float rightPosX = Random.Range(rightPosX_Min, rightPosX_Max);
                float rightPosZ = Random.Range(rightPosZ_Min, rightPosZ_Max);
                transform.position = new Vector3(rightPosX, transform.position.y, rightPosZ);
            }
        }
    }
}
