using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Object spins on the x axis
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * 50);
    }
}
