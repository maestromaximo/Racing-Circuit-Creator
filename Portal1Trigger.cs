using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1Trigger : MonoBehaviour
{
    public GameObject player;
    public GameObject portal2;
    public GameObject cam;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car")
        {
            player.transform.position = portal2.transform.position - portal2.transform.forward*3f;
            //Quaternion lookAt = Quaternion.LookRotation(portal2.transform.forward + player.transform.forward, player.transform.up);

            Quaternion lookAt = Quaternion.LookRotation(-portal2.transform.forward, Vector3.up);
            player.transform.rotation = lookAt;
            //player.transform.rotation = portal2.transform.rotation;
            RbWork();
        }

    }

    private void RbWork()
    {
        Rigidbody car = player.GetComponent<Rigidbody>();

        float speed = car.velocity.magnitude;

        Vector3 velocity = player.transform.forward.normalized * speed;
        car.velocity = velocity;
    }
}
