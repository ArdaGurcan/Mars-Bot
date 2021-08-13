using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


	private void OnCollisionStay(Collision collision)
	{
        //Debug.Log(collision.collider.name);
        if(collision.collider.tag != "Player")
            Destroy(transform.parent.gameObject);
	}
}
