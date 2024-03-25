using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float speed = 0.012f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += Vector3.left * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += Vector3.right * speed;
        }

    }
}
