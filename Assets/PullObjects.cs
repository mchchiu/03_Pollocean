using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullObjects : MonoBehaviour
{
    public GameObject Player;
    public GameObject ObjectA;
    public GameObject ObjectB;
    public bool InRange;
    bool Keypressed;
    public GameObject RecycledObjectA;
    public GameObject RecycledObjectB;
    public GameObject Graphics;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
            if((Input.GetKey(KeyCode.E)) && (InRange == true))
            {
                if(ObjectA !=null)
                {
                    // Debug.Log("True True");
                    ObjectA.transform.position = Vector3.MoveTowards(ObjectA.transform.position, Player.transform.position, 2f * Time.deltaTime);
                    Graphics.SetActive(true);
                }
                if(ObjectB !=null)
                {
                    ObjectB.transform.position = Vector3.MoveTowards(ObjectB.transform.position, Player.transform.position, 2f * Time.deltaTime);
                    Graphics.SetActive(true);
                }
            }
            else
            {
                // Debug.Log("True False");
                Graphics.SetActive(false);
            }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ObjectA")
        {
            Destroy(collision.gameObject);
            Instantiate(RecycledObjectA, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }

        if(collision.gameObject.tag == "ObjectB")
        {
            Destroy(collision.gameObject);
            Instantiate(RecycledObjectB, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if((col.gameObject.tag == "ObjectA") )
        {
            ObjectA = col.gameObject;
            InRange = true;
        }
        if((col.gameObject.tag == "ObjectB") )
        {
            ObjectB = col.gameObject;
            InRange = true;
        }
    }

    public void OnTriggerExit(Collider coll)
    {
        if((coll.gameObject.tag == "ObjectA")||(coll.gameObject.tag == "ObjectB"))
        {
            InRange = false;
        }
    }
}
