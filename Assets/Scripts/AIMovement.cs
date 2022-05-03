using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    NavMeshAgent m_Agent;

    
    [SerializeField] int index;
    [SerializeField] List<GameObject> _waypoints;
    [SerializeField] GameObject[] _patrol;
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        index = 0;
        m_Agent.SetDestination(_patrol[index].transform.position);
    }
    private void Update()
    {
        Debug.Log(m_Agent.remainingDistance);
        //Debug.Log(m_Agent.pathStatus);
        if (m_Agent.remainingDistance <= 0.1f)
        {
            //Debug.Log("Path complete");
            index++;
            if (index >= _patrol.Length)
            {
                index = 0;
            }
            m_Agent.SetDestination(_patrol[index].transform.position);
        }
    }
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
    //        m_Agent.SetDestination(_patrol[index].transform.position);
    //    }
    //    Debug.Log("collide!");
    //}
}
