using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpot : MonoBehaviour
{
    // Static
    Transform playerCamera;

    // Public
    public PortalSpot destination;
    public Transform portalCamera;
    public MeshRenderer portalQuad;

    // Private
    RenderTexture portalTexture;

    // Events
    void Awake()
    {
        portalTexture = new RenderTexture(Screen.width, Screen.height, 16);
        portalTexture.Create();
        portalQuad.material.mainTexture = portalTexture;
    }

    void Start ()
    {
        // Get player's transform
        if (playerCamera == null)
        {
            playerCamera = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
        }

        // Set portalCamera's target texture
        portalCamera.GetComponent<Camera>().targetTexture = portalTexture;
        //portalCamera.parent = null;
    }
	
	void Update ()
    {
        if (destination != null)
            handlePortalCamera();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float zPos = transform.InverseTransformPoint(playerCamera.position).z;
            //print(zPos);
            if (zPos > 0)
                teleportPlayer();
        }
    }

    // Private functions
    void handlePortalCamera()
    {
        Quaternion Rot180 = Quaternion.Euler(0, 180.0f, 0);
        Vector3 LocalPos = transform.InverseTransformPoint(playerCamera.position);
        Vector3 RotatedPos = Rot180 * LocalPos;
        portalCamera.position = destination.transform.TransformPoint(RotatedPos);
        portalCamera.rotation = destination.transform.rotation * Rot180 * Quaternion.Inverse(transform.rotation) * playerCamera.rotation;
    }

    void teleportPlayer()
    {
        //print("Teleporting to: " + destination.gameObject.name);

        Transform player = playerCamera.parent;

        Vector3 localPos = transform.InverseTransformPoint(player.position);
        localPos.x *= -1;
        localPos.z *= -1;
        player.position = destination.transform.TransformPoint(localPos);// - destination.transform.forward*0.01f;

        player.rotation = Quaternion.Euler(0, portalCamera.rotation.eulerAngles.y, 0);

        // The fucking fuck did you just say to me
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().ReInitMouseLook();
    }
}