using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    public Transform pointA;
    public Transform pointB;
    [SerializeField] private bool reverseMove = false;
    [SerializeField] private Transform objectToUse;
    [SerializeField] private bool moveThisObject = false;
    private float startTime;
    private float journeyLength;
    private float distCovered;
    private float fracJourney;
    public GameObject hitobj;

    public int health = 100;
    void Start()
    {
        startTime = Time.time;
        if (moveThisObject)
        {
            objectToUse = transform;
        }
        journeyLength = Vector2.Distance(pointA.position, pointB.position);
    }


    public void Takedamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

     void Die()
    {
        Destroy(hitobj);

    }
    void Update()
    {

        
        distCovered = (Time.time - startTime) * moveSpeed;
        fracJourney = distCovered / journeyLength;
        if (reverseMove)
        {
            objectToUse.position = Vector3.Lerp(pointB.transform.position, pointA.transform.position, fracJourney);
        }
        else
        {
            objectToUse.position = Vector3.Lerp(pointA.transform.position, pointB.transform.position, fracJourney);
        }
        if ((Vector3.Distance(objectToUse.position, pointB.transform.position) == 0.0f || Vector3.Distance(objectToUse.position, pointA.transform.position) == 0.0f)) //Checks if the object has travelled to one of the points
        {
            if (reverseMove)
            {
                reverseMove = false;
            }
            else
            {
                reverseMove = true;
            }
            startTime = Time.time;
        }
    }
}