using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public Vector3 rotationPoint;
    float zoomSpeed = 2.5f;
    float rotationAngle = 60f;
    float rotationConstant;
    float zoomConstant;
    public GameObject cameraMenu;

    private void Update()
    {
        transform.eulerAngles += new Vector3(0, rotationConstant * rotationAngle * Time.deltaTime);

        if (transform.GetChild(0).GetComponent<Camera>().orthographicSize > 1 && zoomConstant < 0)
        {
            transform.GetChild(0).GetComponent<Camera>().orthographicSize -= zoomSpeed * Time.deltaTime;

        }

        if (transform.GetChild(0).GetComponent<Camera>().orthographicSize < 15 && zoomConstant > 0)
        {
            transform.GetChild(0).GetComponent<Camera>().orthographicSize += zoomSpeed * Time.deltaTime;

        }
    }

    public void ToggleCamMenu()
    {
        cameraMenu.SetActive(!cameraMenu.activeSelf);
    }

    //public void RotateCCW()
    //{
    //    transform.eulerAngles -= new Vector3(0, rotationAngle * Time.deltaTime);
    //}

    //public void RotateCW()
    //{
    //    transform.eulerAngles += new Vector3(0, rotationAngle * Time.deltaTime);
    //}

    public void SetRotation(int rotationValue)
    {
        rotationConstant = rotationValue;
    }

    public void SetZoom(int zoomValue)
    {
        zoomConstant = zoomValue;
    }

    //public void ZoomIn()
    //{
    //    if(transform.GetChild(0).GetComponent<Camera>().orthographicSize > 1)
    //    {
    //        transform.GetChild(0).GetComponent<Camera>().orthographicSize -= zoomSpeed;

    //    }
    //}
    //public void ZoomOut()
    //{
    //    if (transform.GetChild(0).GetComponent<Camera>().orthographicSize < 15)
    //    {
    //        transform.GetChild(0).GetComponent<Camera>().orthographicSize += zoomSpeed;

    //    }    
    //}
}