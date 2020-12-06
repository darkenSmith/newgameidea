using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletprefab;
    private float timer = 10.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer -= 1;
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }


    public void shoot()
    {
        Debug.Log("fire");
        Instantiate(bulletprefab, firepoint.position, firepoint.rotation);

        

        

        
    }



}
