using System.Collections;
using UnityEngine;

public class FootController : MonoBehaviour 
{
    private ElephantController elephantController;

    [Header("Step Attributes")]
    public bool isMakingAStep;

    private float stepDistance;
    private float stepHeight;
    private float stepSpeed;

    private Vector3 stepUpVec;
    private Vector3 stepDownVec;
    private Vector3 nextPos;
    private float t;

	void Start () 
    {
        elephantController = gameObject.transform.parent.GetComponent<ElephantController>();

        stepDistance = elephantController.stepDistance;
        stepSpeed = elephantController.stepSpeed;
        stepHeight = elephantController.stepHeight;
	}
	
	void FixedUpdate () 
    {
		if (isMakingAStep)
        {
            transform.position = Vector3.Lerp(transform.position, nextPos, t);

            t += stepSpeed * Time.deltaTime;

            if (transform.position == nextPos)
            {
                isMakingAStep = false;
                t = 0;          
                //Step to next Pos;  
            }
        }
	}

    public void StepUp()
    {
        Vector3 forwardVec = transform.forward;
        forwardVec.Scale(new Vector3(stepDistance / 2, 0, stepDistance / 2));
        Debug.Log(forwardVec);
        stepUpVec = transform.position + forwardVec;    
        stepUpVec += new Vector3(0, stepHeight, 0);
        nextPos = stepUpVec;
        Debug.Log(gameObject.name + " " + nextPos);
        //isMakingAStep = true;
    }

    public void StepDown()
    {
        Vector3 forwardVec = transform.forward;
        forwardVec *= stepDistance / 2;
        Debug.Log(forwardVec);
        stepDownVec = transform.position + transform.forward;
        stepDownVec -= new Vector3(0, -stepHeight, 0);
        nextPos = stepDownVec;
        Debug.Log(gameObject.name + " " + nextPos);
        //isMakingAStep = true;
    }
}
