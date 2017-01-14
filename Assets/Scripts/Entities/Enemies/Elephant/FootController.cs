using System.Collections;
using UnityEngine;

public class FootController : MonoBehaviour 
{
    private ElephantController elephantController;

    [Header("Step Attributes")]
    public bool isMakingAStepUp;
    public bool isMakingAStepDown;

    private float stepDistance;
    private float stepHeight;
    private float stepSpeed;

    private Vector3 stepUpVec;
    private Vector3 stepDownVec;
    private Vector3 nextPos;
    private float t;

	void Awake () 
    {
        elephantController = gameObject.transform.parent.GetComponent<ElephantController>();

        stepDistance = elephantController.stepDistance;
        stepSpeed = elephantController.stepSpeed;
        stepHeight = elephantController.stepHeight;
	}
	
	void FixedUpdate () 
    {
        ManageFootMovement();
    }

    void ManageFootMovement()
    {
        if (isMakingAStepUp)
        {
            transform.position = Vector3.Slerp(transform.position, nextPos, t);

            t += stepSpeed * Time.deltaTime;

            if (transform.position == nextPos)
            {
                isMakingAStepUp = false;
                t = 0;
                StepDown();
            }
        }

        if (isMakingAStepDown)
        {
            transform.position = Vector3.Slerp(transform.position, nextPos, t);

            t += stepSpeed * Time.deltaTime;

            if (transform.position == nextPos)
            {
                isMakingAStepDown = false;
                elephantController.canStep = true;
                t = 0;
            }
        }
    }

    public void StepUp()
    {
        stepUpVec = transform.position + (transform.forward * (stepDistance / 2));
        stepUpVec.y = stepHeight;
        nextPos = stepUpVec;
        isMakingAStepUp = true;
    }

    public void StepDown()
    {
        stepDownVec = transform.position + (transform.forward * (stepDistance / 2));
        stepDownVec.y = 0;
        nextPos = stepDownVec;
        isMakingAStepDown = true;
    }
}
