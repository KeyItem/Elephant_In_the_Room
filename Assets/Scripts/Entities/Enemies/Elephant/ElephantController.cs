using System.Collections;
using UnityEngine;

public class ElephantController : MonoBehaviour 
{
    private TimerClass stepTimer;

    [Header("Elephant Target")]
    public GameObject Player;
    [Space(10)]
    public GameObject[] wayPoints;

    public float moveSpeed;

    public bool canMove;

    public bool isFollowingPath;

    [Header("Elephant Foot Attributes")]
    public GameObject[] feet;

    private int previousFoot = -1;

    public bool canStep;

    [Header("Step Attributes")]
    public float stepDistance;
    public float stepSpeed;
    public float stepHeight;

    [Header("Timer Attributes")]
    public float minTime;
    public float maxTime;
    private float nextStepTime;

    private void Start()
    {
        stepTimer = new TimerClass();

        CalculateNextFoot();
    }

    private void Update()
    {
        ManageStep();

        ManageMoving();
    }

    private void ManageMoving()
    {
        if (canMove)
        {
            if (isFollowingPath) //Follows Player
            {
                Vector3 interceptVec = Player.transform.position - transform.position;
            }
            else
            {
               //For Patrol
            }
        }
    }

    private void ManageStep()
    {
        if (stepTimer.TimerIsDone() && canStep)
        {
            CalculateNextFoot();
        }
    }

    private void CalculateNextFoot()
    {
        if (canStep)
        {
            int randValue = Random.Range(0, feet.Length);

            if (randValue != previousFoot)
            {
                feet[randValue].GetComponent<FootController>().StepUp();

                nextStepTime = Random.Range(minTime, maxTime);
                Debug.Log("Step!");

                previousFoot = randValue;

                stepTimer.ResetTimer(nextStepTime);
            }
            else
            {
                CalculateNextFoot();
                Debug.Log("Recalculating");
            }
        }    
    }
}
