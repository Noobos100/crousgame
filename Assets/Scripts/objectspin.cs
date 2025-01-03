using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpin : MonoBehaviour
{
    private bool isPickedUp = false; // Flag to check if the object is picked up

    void Update()
    {
        if (!isPickedUp)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * 50);
        }
    }

    // Method to stop spinning, called by the pickup script
    public void StopSpinning()
    {
        isPickedUp = true;
    }
}