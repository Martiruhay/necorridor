using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    Transform player;
    Transform playerCamera;
    //Vector3 offset;
    public Transform portal1, portal2;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found");
        }
        playerCamera = player.GetChild(0);

        //offset = player.position - transform.position;
    }
	
	void Update ()
    {
        Quaternion Rot180 = Quaternion.Euler(0, 180.0f, 0);
        Vector3 LocalPos = portal1.InverseTransformPoint(playerCamera.position);
        Vector3 RotatedPos = Rot180 * LocalPos;
        transform.position = portal2.TransformPoint(RotatedPos);
        transform.rotation = portal2.rotation * Rot180 * Quaternion.Inverse(portal1.transform.rotation) * transform.rotation;

        //Vector3 newPos = portal1.InverseTransformPoint(playerCamera.position);
        //transform.localPosition = new Vector3(-newPos.x, newPos.y, -newPos.z);
        //
        //Vector3 playerToPortal = portal1.position - playerCamera.position;
        //float angleTest = Vector3.SignedAngle(-portal1.transform.forward.normalized, playerToPortal.normalized, Vector3.up);
        //
        //Debug.DrawLine(playerCamera.position, portal1.position);
        //Debug.DrawRay(portal1.position, portal1.forward * 100, Color.blue);
        //
        //float angle = Vector3.SignedAngle(-portal1.transform.forward, player.forward, Vector3.up);
        //print(angleTest);
        //
        //transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, angleTest, transform.localEulerAngles.z);
        //transform.forward = playerToPortal.normalized;
        //print(transform.localEulerAngles);

        //print(angle);
    }
}