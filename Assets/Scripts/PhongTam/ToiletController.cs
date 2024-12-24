using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletController : MonoBehaviour
{
    public GameObject puppet;
    private Vector3 customPosition = new Vector3(-10.43f, 0.43f, 6.86f);
    private Quaternion customRotation = Quaternion.Euler(0f, -180f, 0f); // Custom rotation with y = -90

    public void SitOnToilet()
    {
        if (puppet != null)
        {
            puppet.transform.position = customPosition; // Set position
            puppet.transform.rotation = customRotation; // Set rotation
        }
        else
        {
            Debug.LogWarning("Puppet reference is not assigned in ToiletController!");
        }
    }
}

