using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footMove : MonoBehaviour {

    public Transform target;

    public float turnOff = 2f;

    public float moveSpeed;

    void OnEnable()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        turnOff = 2f;
    }

    void Update ()
    {
        //mov to playr
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, target.position.z), moveSpeed * Time.deltaTime);

        //stomp
        if(turnOff > 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z), moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y - 8f, transform.position.z), moveSpeed * Time.deltaTime);
        }

        //timer
        turnOff -= Time.deltaTime;

        //disable
        if (turnOff < 0)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            this.enabled = false;

        }
    }
}
