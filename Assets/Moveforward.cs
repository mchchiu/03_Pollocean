using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveforward : MonoBehaviour
{
    // public Transform originalObject;
    // public Transform reflectedObject;
    // Start is called before the first frame update
    private Rigidbody rb;
    Vector3 LastVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0,0,5*-50f));
    }

    // Update is called once per frame
    void Update()
    {
        LastVelocity = rb.velocity;
        // Vector3 v3Force = -0.5f*transform.forward;
        // GetComponent<Rigidbody>().AddForce(v3Force);
        // reflectedObject.position = Vector3.Reflect(originalObject.position, Vector3.right);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Before" + collision.gameObject.tag);
        if(collision.gameObject.tag != "Player")
        {   
            // Debug.Log(collision.gameObject.tag);
            Destroy(gameObject);
        }
        else
        {
            // Debug.Log(collision.gameObject.tag);
            var speed = LastVelocity.magnitude;
            var direction = Vector3.Reflect(LastVelocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction*Mathf.Max(speed, 0f);
        }
    }
}
