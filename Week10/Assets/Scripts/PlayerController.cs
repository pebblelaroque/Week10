using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{
    public ThirdPersonCharacter character;

    public Camera cam;

    public NavMeshAgent agent;

    private void Start()
    {
        {
            if (cam == null)
            {
                cam = Camera.main;
            }

            if (agent == null)
            {
                agent = GetComponent<NavMeshAgent>();
            }

            agent.updateRotation = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                //move agent
                agent.SetDestination(hit.point);
            }
        }

        if(agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
        
    }
}
