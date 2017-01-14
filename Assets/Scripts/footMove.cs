using System.Collections;
using UnityEngine;

public class footMove : MonoBehaviour
{
    private TimerClass timerClass;

    [Header("Step Variables")]
    public GameObject Player;

    private Vector3 stepUpVec;
    private Vector3 stepDownVec;

    public float stepUpDistance;
    public float stepForwardDistance;

    public float footStepSpeed;

    void Start()
    {
        timerClass = new TimerClass();

        CalculateNextStep();
    }

    void Update ()
    {
        
    }

    void CalculateNextStep()
    {
        Vector3 currentPos = transform.position;

        Vector3 playerPos = Player.transform.position;

        Vector3 interceptVec = playerPos - currentPos;

        Debug.Log(interceptVec);
    }
}
