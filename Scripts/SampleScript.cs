using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScript : MonoBehaviour
{
    GameObject player;
    static int totalSamples = 0;
    public static List<GameObject> samples = new List<GameObject>();
	// Start is called before the first frame update
	private void Awake()
	{
        if(totalSamples != 0)
        {
            totalSamples = 0;
        }

        if (samples.Count != 0)
        {
            samples.Clear();
        }
	}

	void Start()
    {
        
        //transform.Rotate(0, Random.Range(0,4) * 90, 0);
        player = GameObject.FindWithTag("Player");
        totalSamples++;
        samples.Add(gameObject);
        //samples.
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 1);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if(other.tag == "Player")
        {
            GetComponent<MeshRenderer>().enabled = false;

        }
        else
        {
            
            if (other.tag != "Player")
            {
                Destroy(gameObject);

            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<MeshRenderer>().enabled = true;

    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
}
