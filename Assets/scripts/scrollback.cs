using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollback : MonoBehaviour {
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 Screenbounds;
    public float choke;


void Start(){
        mainCamera = gameObject.GetComponent<Camera>();
        Screenbounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach(GameObject obj in levels) {


            loadChildObjects(obj);

        }
    }

    void loadChildObjects(GameObject obj){
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
        int childNeeded = (int)Mathf.Ceil(Screenbounds.x * -2 / objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for(int i = 0; i <= childNeeded; i++){

            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
                }

        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
      
        }

  

     void repositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if(children.Length > 1)
        {
            GameObject firstchild = children[1].gameObject;
            GameObject lastchild = children[children.Length - 1].gameObject;
            float halfobjectw = lastchild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;
            if(transform.position.x + Screenbounds.x > lastchild.transform.position.x + halfobjectw){
                firstchild.transform.SetAsLastSibling();
                firstchild.transform.position = new Vector3(lastchild.transform.position.x + halfobjectw * 2, lastchild.transform.position.y, lastchild.transform.position.z);   
            }else if (transform.position.x - Screenbounds.x < firstchild.transform.position.x - halfobjectw){
                lastchild.transform.SetAsFirstSibling();
                lastchild.transform.position = new Vector3(firstchild.transform.position.x - halfobjectw *  2, firstchild.transform.position.y, firstchild.transform.position.z);
            }
        }
    }


    void LateUpdate()
    {
        foreach (GameObject obj in levels)
        {
            repositionChildObjects(obj);



        }

    }
}