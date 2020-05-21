using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChickenScript : MonoBehaviour
{

    public NavMeshAgent nm;
    public float AttackingDistance;
    public float DetectionDistance;

    public Transform thePlayer;
    public Animator anim;

    private void Update()
    {
        StartCoroutine(Think());
    }

    IEnumerator Think()
    {
        yield return new WaitForSeconds(.25f);

        float dist = Vector3.Distance(thePlayer.position, transform.position);

        if(dist <= DetectionDistance)
        {
            anim.SetBool("Run", true);
            anim.SetBool("Eat", false);
            nm.isStopped = false;
            nm.SetDestination(thePlayer.position);
        }
        if(dist <= AttackingDistance)
        {
            anim.SetBool("Eat", true);
            anim.SetBool("Run", false);
            nm.isStopped = true;
        }
        if(dist >= DetectionDistance)
        {
            anim.SetBool("Run", false);
            anim.SetBool("Eat", false);
            nm.isStopped = true;
        }
    }
}
