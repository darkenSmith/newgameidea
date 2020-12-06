using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //When the Primitive collides with the walls, it will reverse direction
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("hey dont");
    }
}
