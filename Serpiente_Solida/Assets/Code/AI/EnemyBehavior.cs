using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public float visionRange;
    public float visionConeAngle;
    public bool alerted;
    Rigidbody ourRigidBody;
    public Light myLight;

    // Start is called before the first frame update
    void Start()
    {
        alerted = false;
        ourRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 vectorToPlayer = playerPosition - transform.position;
        myLight.color = Color.white;

        if (alerted)
        {
            //Follow the player
            ourRigidBody.velocity = vectorToPlayer.normalized * speed;
            Vector3 playerPositionAtOurHeight = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
            transform.LookAt(playerPositionAtOurHeight);
            myLight.color = Color.red;


        }
        else
        {
            //Checking if we can see the player
            if(Vector3.Distance(transform.position, playerPosition) <= visionRange)
            {
                if(Vector3.Angle(transform.forward, vectorToPlayer) <= visionConeAngle)
                {
                    alerted = true;
                }
            }
        }

        //Checking if player run out of vision.
        if (Vector3.Distance(transform.position, playerPosition) > visionRange)
        {
            alerted = false;
        }

    }
}


