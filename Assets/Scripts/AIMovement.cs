using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected NavMeshAgent m_Agent;
    [SerializeField] protected Animator animator;
    [Header("Waypoint stuff")]
    [SerializeField] protected int index;
    [SerializeField] protected List<GameObject> waypoints;
    [SerializeField] protected GameObject[] patrol;
    [SerializeField] protected bool hasKey;

    //because .remainingDistance and .pathStatus doesnt work with height
    protected float AIDistance(GameObject agent, GameObject target)
    {
        Vector3 agentPos = agent.transform.position;
        Vector3 targetPos = target.transform.position;
        float difference = Mathf.Abs(agentPos.x - targetPos.x) + Mathf.Abs(agentPos.y - targetPos.y) + Mathf.Abs(agentPos.z - targetPos.z);
        return difference;
    }
    //next waypoint on a patrol
    protected void NextPatrol()
    {
        index++;
        if (index >= patrol.Length)
        {
            index = 0;
        }
        m_Agent.SetDestination(patrol[index].transform.position);
    }
    //every agent has this same code
    protected void CheckAnim(NavMeshAgent agent)
    {
        //if walking, set animator to walk
        if (AgentSpeed(agent) > 0)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }
    //for some reason this function is missing
    float AgentSpeed(NavMeshAgent agent)
    {
        float value = Mathf.Abs(agent.velocity.x) + Mathf.Abs(agent.velocity.y);
        return value;
    }
    #region Test stuff
    /*
    void Start()
    {
        isPatrolling = true;
        m_Agent = GetComponent<NavMeshAgent>();
        index = 0;
        m_Agent.SetDestination(patrol[index].transform.position);
    }
    private void Update()
    {
        //Debug.Log(m_Agent.remainingDistance);
        //Debug.Log(m_Agent.pathStatus);
        //Debug.Log(AIDistance(gameObject, patrol[index]));
        //if (m_Agent.remainingDistance <= 0.1f)
        //if (m_Agent.pathStatus == NavMeshPathStatus.PathComplete)
        Debug.Log(patrol[index].tag);
        if (AIDistance(gameObject, patrol[index]) <= 0.5f && isPatrolling)
        {
            //check if key, disable key if true and enable haskey
            if (patrol[index].tag == "Key")
            {
                GameManager.OpenGate();
                patrol[index].SetActive(false);
            }
            //check if door, if door and haskey == true disable door
            //Debug.Log("Path complete");
            index++;
            if (index >= patrol.Length)
            {
                index = 0;
            }
            m_Agent.SetDestination(patrol[index].transform.position);
        }
    }
    */
    //didnt work
    //private void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.tag == "Patrol")
    //    {
    //        index++;
    //        if (index >= 2)
    //        {
    //            index = 0;
    //        }
    //        m_Agent.SetDestination(patrol[index].transform.position);
    //    }
    //    Debug.Log("collide!");
    //}
    #endregion
}
