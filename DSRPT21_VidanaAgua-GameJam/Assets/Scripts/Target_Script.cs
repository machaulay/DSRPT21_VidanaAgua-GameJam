using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target_Script : MonoBehaviour
{
    GameControle gameControle;
    GameObject orcPlayer;
    public GameObject TargetMesh;
    public GameObject redAlert;


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

        redAlert.SetActive(false);

    }

    void Update()
    {
        AnimationChange(isRunning);

        if (Vector3.Distance(transform.position, target.transform.position) < safeDistance)
        {
            agent.destination = target.transform.position;

            isRunning = true;
            redAlert.SetActive(true);

            //troca prancheta na mão


        }
        else
        {
            redAlert.SetActive(false);

            //retorna a prancheta na mão

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

    //public IEnumerator RedAlert()
    //{
    //    tocando = true;
    //    yield return new WaitForSeconds(3.0f);
    //    tocando = false;
    //    redAlert.SetActive(false);

    //}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
    }
}
