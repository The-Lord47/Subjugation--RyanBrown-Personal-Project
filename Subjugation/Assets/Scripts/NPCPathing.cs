using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCPathing : MonoBehaviour
{
    NavMeshAgent agent;

    bool atDestination = true;

    string destination;

    float timer;

    //---------------PUBLIC VARIABLES---------------
    public string destination1Tag;
    public string destination2Tag;

    public float destinationDistance;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = destination2Tag;
    }

    // Update is called once per frame
    void Update()
    {
        //---------------NPC Path Patrolling---------------
        Debug.Log(destination);

        //if the NPC is at the destination, make it wait there for 5 seconds
        if (atDestination == true)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                timer = 0;
                atDestination = false;
                if (destination == destination1Tag)
                {
                    destination = destination2Tag;
                }
                else
                {
                    destination = destination1Tag;
                }
            }
        }

        //if the NPC is not yet at the destination then make it go towards it
        if (atDestination == false)
        {
            agent.destination = GameObject.FindGameObjectWithTag(destination).transform.position;
        }

        //if the NPC gets within the destination distance for the first time, set the atDestination to true and switch the destination
        if (Vector3.Distance(transform.position, agent.destination) <= destinationDistance && atDestination == false)
        {
            atDestination = true;
        }
    }
}
