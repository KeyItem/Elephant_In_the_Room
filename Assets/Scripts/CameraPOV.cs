using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPOV : MonoBehaviour {


    public float povTransition;

    public bool povZoomIn;
    public bool povZoomOut;

    public float minPov = 1f;
    public float maxPov = 60f;

    public float transitionSpeed;
	
	void Update ()
    {
        if (povZoomIn)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, minPov, povTransition);

            povTransition += transitionSpeed * Time.deltaTime;

            if(Camera.main.fieldOfView == minPov)
            {
                povZoomIn = false;
                povTransition = 0f;
            }
        }

        if (povZoomOut)
        {

            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, maxPov, povTransition);

            povTransition += transitionSpeed * Time.deltaTime;

            if (Camera.main.fieldOfView == maxPov)
            {
                povZoomOut = false;
                povTransition = 0f;
            }
        }
	}
}
