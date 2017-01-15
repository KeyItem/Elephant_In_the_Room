using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_ctrl : MonoBehaviour {

    public bool trapActive;
    public float timer;
    public bool deathTrg;
    public Animator trapAnim;
    public bool doOnce;


    void Update ()
    {
        if (trapActive)
        {
            timer -= Time.deltaTime;

            if (!doOnce)
            {
                trapAnim.SetBool("trapOn", true);
                doOnce = true;
            }
        }

        if(timer <= 0)
        {
            deathTrg = true;
        }

        if(timer <= -1f) //death trigger delay
        {
            deathTrg = false; //stop death trigger
            trapActive = false; //close timer
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            trapActive = true;

            if (deathTrg)
            {
                //player death
                other.gameObject.SetActive(false);
            }
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (deathTrg)
            {
                //player death
                other.gameObject.SetActive(false);
            }
        }
    }

}
