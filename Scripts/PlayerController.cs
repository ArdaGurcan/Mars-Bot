using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int collectedSamples = 0;
    public bool finishedStage;
    GameObject sample;
    public LayerMask mask;
    public GameObject sceneMaster;
    public bool shownPopup;

	private void Start()
	{
        sceneMaster = GameObject.Find("SceneMaster");
	}

	void Update()
    {
        if(finishedStage && !shownPopup)
        {
            shownPopup = true;
            sceneMaster.GetComponent<SceneMaster>().ShowPopup();
        }
        Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), transform.forward, Color.green);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Forward();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateClockwise();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateCounterClockwise();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Collect();
        }
    }


    public void Forward()
    {

        if (!Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, 1f, mask))
        {
            RaycastHit hit;
            transform.position += transform.forward;
            Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), -transform.up, out hit, 100, mask);
            //Debug.Log("Distance: " + hit.distance);

            if (hit.distance > 0)
            {
                transform.position += -transform.up * hit.distance + new Vector3(0, transform.lossyScale.y / 2);
            }
            else
            {
                transform.position -= transform.forward;
            }
        }

    }

    public void Jump()
    {

        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, 1f, mask))
        {
            transform.position += transform.up;
            Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, 1, mask);
            if (!Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, 1, mask))
            {
                transform.position += transform.forward;
            }
            else
            {
                transform.position -= transform.up;
            }
        }
    }

    public void RotateClockwise()
    {
        transform.Rotate(0, 90f, 0);
    }

    public void RotateCounterClockwise()
    {
        transform.Rotate(0, -90f, 0);
    }

    public void Collect()
    {
        if (sample)
        {
            sample.GetComponent<MeshRenderer>().enabled = true;
            sample.SetActive(false);

            sample = null;
            if (!GameObject.FindWithTag("Sample"))
            {
                finishedStage = true;
            }
        }

    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Sample")
        {
            sample = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        sample = null;
    }
	private void OnCollisionEnter(Collision collision)
	{
		
	}



}
