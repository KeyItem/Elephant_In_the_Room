using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elephant_Ctrl : MonoBehaviour {

    //random stomp time
    //slct nxt stomp

    public float stompTimer = 1f;
    public float nxtStomp;
    public float minStompTimr;
    public float maxStompTimr;

    public GameObject[] feetArray;

    public int footSelect = 0;


    void Update ()
    {
        nxtStomp -= Time.deltaTime;

        if (nxtStomp < 0)
            StompTimr();
    }


    void StompTimr()
    {
        //foot selct
        footSelect++;

        if (footSelect > 3)
            footSelect = 0;

        //foot animation and follow
        feetArray[footSelect].GetComponent<footMove>().enabled = true;

        //delay
        nxtStomp = Random.Range(minStompTimr, maxStompTimr);

    }


}
