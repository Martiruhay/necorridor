using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    Transform player;
    Transform playerCamera;
    Vector3 offset;
    public Transform portal1, portal2;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found");
        }
        playerCamera = player.GetChild(0);

        offset = player.position - transform.position;
    }
	
	void Update ()
    {
        Vector3 newPos = portal1.InverseTransformPoint(player.position);
        transform.localPosition = new Vector3(-newPos.x, transform.localPosition.y, -newPos.z);

        float angle = Vector3.SignedAngle(-portal1.transform.forward, player.forward, Vector3.up)/2;
        transform.localRotation = Quaternion.Euler(0, angle, 0);

        //print(angle);
    }
}