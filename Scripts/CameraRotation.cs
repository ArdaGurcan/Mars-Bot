using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    bool foundPoint = false;
    public Vector3 point;
    public float xSum;
    public float zSum;
    public static bool done;
    public static List<Vector3> blockPositions = new List<Vector3>();
    public GameObject mainCamera;
	// Start is called before the first frame update
	private void Awake()
	{
		if(done)
        {
            done = false;
        }
        if(blockPositions.Count != 0)
        {
            blockPositions.Clear();
        }
    }

    void Start()
    {
        mainCamera = mainCamera.transform.parent.gameObject;
        if (!blockPositions.Contains(transform.position))
        {
            blockPositions.Add(transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!foundPoint)
        {
            foundPoint = true;
            foreach (var position in blockPositions)
            {
                xSum += position.x;
                zSum += position.z;
            }
            point = new Vector3(xSum / blockPositions.Count, 0, zSum / blockPositions.Count);
            mainCamera.GetComponent<CameraRotator>().rotationPoint = point;
            mainCamera.transform.position = point;
        }

    }
}
