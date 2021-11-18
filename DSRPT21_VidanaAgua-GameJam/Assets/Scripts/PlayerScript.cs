using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject PlayerMesh;
    public GameObject ObjectRay;
    public float speed;
    public float attackDistance;
    public float offSet;

    private Animator _anim;

    void Start()
    {
        _anim = PlayerMesh.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Enemy" && Vector3.Distance(transform.position,
                        new Vector3(hit.point.x, transform.position.y, hit.point.z)) <= attackDistance)
                    {
                        _anim.SetTrigger("pAttack");
                        _anim.SetInteger("whichAttack", Random.Range(1, 3));
                    }
                }
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 direct = new Vector3(hit.point.x, transform.position.y,
                        hit.point.z);

                    if (Vector3.Distance(transform.position, direct) > offSet)
                    {
                        transform.position = Vector3.MoveTowards(transform.position, direct, speed * Time.deltaTime);
                        _anim.SetFloat("pMove", Vector3.Distance(transform.position, direct));

                    }

                    transform.LookAt(direct);

                    if (Mathf.Round(Vector3.Distance(transform.position, direct)) == offSet)
                    {
                        _anim.SetFloat("pMove", 0.0f);
                    }
                    

                    if (Vector3.Distance(transform.position, direct) > 0)
                    {
                        speed = 5.0f;
                        _anim.SetBool("pRun", true);
                    }
                    //else
                    //{
                    //    speed = 2.5f;
                    //    _anim.SetBool("pRun", false);

                    //}
                }
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                _anim.SetTrigger("pAttack");
                _anim.SetFloat("pMove", 0.0f);
                _anim.SetBool("pRun", false);
                speed = 2.5f;
            }
        }
    }
}
