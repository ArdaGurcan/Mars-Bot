using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public bool x;
    public bool y;
    public bool z;
    public float speed = 1;
    public bool spin = true;
    Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = new Vector3(System.Convert.ToInt32(x) * speed, System.Convert.ToInt32(y) * speed, System.Convert.ToInt32(z) * speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (spin)
            transform.Rotate(rotation * Time.deltaTime);
    }
}
