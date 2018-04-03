using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    Transform player;
    Transform playerCamera;
    public Transform portal1, portal2;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found");
        }
        playerCamera = player.GetChild(0);
    }
	
	void Update ()
    {
        Vector3 cameraPositionInSourceSpace = portal1.InverseTransformPoint(playerCamera.position);
        Quaternion cameraRotationInSourceSpace = Quaternion.Inverse(portal1.rotation) * playerCamera.rotation;

        transform.position = portal2.TransformPoint(cameraPositionInSourceSpace);
        transform.rotation = portal2.rotation * cameraRotationInSourceSpace;
    }
}