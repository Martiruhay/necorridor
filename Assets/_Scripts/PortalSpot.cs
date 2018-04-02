using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpot : MonoBehaviour
{
    public int id;
    public PortalSpot nextSpot;
    public Transform spawnPoint;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PortalsController.instance.Teleport(id);
        }
    }
}