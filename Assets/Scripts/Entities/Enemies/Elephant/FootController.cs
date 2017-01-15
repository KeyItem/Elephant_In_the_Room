using System.Collections;
using UnityEngine;

public class FootController : MonoBehaviour 
{
    private ElephantController elephantController;

    [Header("Step Attributes")]
    public bool isMakingAStepUp;
    public bool isMakingAStepDown;

    private float stepDistanceMin;
    private float stepDistanceMax;

    private float stepHeight;
    private float stepSpeed;

    private Vector3 stepUpVec;
    private Vector3 stepDownVec;
    private Vector3 nextPos;
    private float t;

	void Awake () 
    {
        elephantController = gameObject.transform.parent.GetComponent<ElephantController>();

        stepDistanceMin = elephantController.stepDistanceMin;
        stepDistanceMax = elephantController.stepDistanceMax;

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
        float randValue = Random.Range(stepDistanceMin, stepDistanceMax);
        stepUpVec = transform.position + (transform.forward * (randValue / 2));
        stepUpVec.y = stepHeight;
        nextPos = stepUpVec;
        isMakingAStepUp = true;
    }

    public void StepDown()
    {
        float randValue = Random.Range(stepDistanceMin, stepDistanceMax);
        Vector3 randMoveVec = new Vector3(randValue, 0, 0);
        stepDownVec = transform.position + randMoveVec;
        stepDownVec.y = 0;
        nextPos = stepDownVec;
        isMakingAStepDown = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isMakingAStepDown)
            {
                Debug.Log("Player was stepped on!");
                StateManager.GameOver();
            }
        }
    }
}
