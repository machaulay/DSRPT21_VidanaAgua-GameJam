using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target_Script : MonoBehaviour
{
    GameControle gameControle;
    GameObject orcPlayer;
    public GameObject TargetMesh;

    [SerializeField] private float safeDistance;
    [SerializeField] private float speed;

    int current_way;
    private bool isRunning;


    private Animator _anim;


    //NavMesh
    private NavMeshAgent agent;
    private GameObject target;

    void Start()
    {

        _anim = TargetMesh.GetComponent<Animator>();

        isRunning = false;

        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        AnimationChange(isRunning);

        if (Vector3.Distance(transform.position, target.transform.position) < safeDistance)
        {
            isRunning = true;


            agent.destination = target.transform.position;


            //transform.LookAt(target.transform.position);
        }
        else
        {
            if (agent.velocity.magnitude < 1.0f)
            {
                isRunning = false;

            }
            else
            {
                isRunning = true;

            }

        }
    }

    void AnimationChange(bool isRunning)
    {
        _anim.SetBool("isRunning", isRunning);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        

    }
}
