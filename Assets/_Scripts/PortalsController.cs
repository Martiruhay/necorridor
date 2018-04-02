using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalsController : MonoBehaviour
{
    public PortalSpot[] portals;

    GameObject player;

    public static PortalsController instance;
    public Vector3 playerRotation;

	void Start ()
    {
        instance = this;

		player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player not found");
        }
	}

    public void Teleport(int portalId)
    {
        player.transform.position = portals[portalId].nextSpot.spawnPoint.position;
        player.transform.rotation = portals[portalId].nextSpot.spawnPoint.rotation;
    }
}