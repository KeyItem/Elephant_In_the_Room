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

	void Start () 
    {
        elephantController = gameObject.transform.parent.GetComponent<ElephantController>();

        stepDistance = elephantController.stepDistance;
        stepSpeed = elephantController.stepSpeed;
        stepHeight = elephantController.stepHeight;
	}
	
	void Update () 
    {
		if (isMakingAStep)
        {

        }
	}

    public void StepUp()
    {
        stepUpVec = transform.position + transform.forward;       
        stepUpVec += new Vector3(0, stepHeight, 0);
        nextPos = stepUpVec;
        Debug.Log(gameObject.name + " " + stepUpVec);
    }

    public void StepDown()
    {
        stepDownVec = transform.position + transform.forward;
        stepDownVec -= new Vector3(0, -stepHeight, 0);
        nextPos = stepDownVec;
        Debug.Log(gameObject.name + " " + stepDownVec);
    }
}
