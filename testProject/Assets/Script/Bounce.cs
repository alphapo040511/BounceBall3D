using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Bounce : MonoBehaviour
{
    public float speed = 5f;
    public float force = 800;
    public float RForce = 800;
    public float jForce = 800;
    public Rigidbody rb;
    public int jumpCount = 0;
    public Material mat1, mat2;
    public MeshRenderer mr;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
    }
    


    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position += Vector3.up * 0.01f * force * Time.deltaTime;

        //if (force >= 0)
        {
            force -= 100f * Time.deltaTime;
        }

       if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += Vector3.forward * speed * Time.deltaTime;
        }
         

        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += Vector3.back * speed * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (jumpCount == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 20f * jForce * Time.deltaTime);

            jumpCount -= 1;

            mr.material = mat1;
        }

        if(jumpCount >= 2)
        {
            jumpCount -= 1;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Double"))
        {
            force = RForce;
            rb.AddForce(Vector3.up * 20f * force * Time.deltaTime);
        }

        if (collision.gameObject.CompareTag("Die"))
        {
            transform.position = new Vector3(0, 1.5f, 0);

            jumpCount = 0;

            mr.material = mat1;
        }

        if (collision.gameObject.CompareTag("Double"))
        {
            jumpCount += 1;
            mr.material = mat2;
         
        }

    }
}
