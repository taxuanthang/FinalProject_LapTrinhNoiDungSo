using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletController : MonoBehaviour
{
    public GameObject puppet;
    private Vector3 customPosition = new Vector3(-10.43f, 0.43f, 6.86f);
    private Quaternion customRotation = Quaternion.Euler(0f, -180f, 0f); // Custom rotation with y = -180
    public AudioSource poopSound; // Reference to the AudioSource for the poop sound
    public AudioSource musicPlay;
    public Camera toiletCamera; // The camera for the toilet view
    public Camera mainCamera; // The main camera
    public Camera showerCamera;
    public void SitOnToilet()
    {
        if (puppet != null)
        {
            puppet.transform.position = customPosition; // Set position
            puppet.transform.rotation = customRotation; // Set rotation

            // Switch to the toilet camera
            if (toiletCamera != null && mainCamera != null)
            {
                mainCamera.enabled = false; // Disable the main camera
                toiletCamera.enabled = true; // Enable the toilet camera
                showerCamera.enabled = false;
            }
            else
            {
                Debug.LogWarning("Cameras are not assigned in ToiletController!");
            }
        }
        else
        {
            Debug.LogWarning("Puppet reference is not assigned in ToiletController!");
        }
    }


    public void Poop()
    {
        if (poopSound != null)
        {
            poopSound.Play(); // Play the poop sound
        }
        else
        {
            Debug.LogWarning("Poop sound is not assigned in ToiletController!");
        }
    }
    public void PlayMusic()
    {
        if (musicPlay != null)
        {
            musicPlay.Play();
        }
        else
        {
            Debug.LogWarning("Poop sound is not assigned in ToiletController!");
        }
    }
}
