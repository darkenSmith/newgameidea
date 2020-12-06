using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class bullet : MonoBehaviour
{

    public int hit = 10;

    public Rigidbody2D projectlie;
    public float spped;
    public float timeRemaining = 20f;
    // Start is called before the first frame update
    void Start()
    {
        projectlie.velocity = transform.right * spped;
        Invoke("DestroyMe", 10);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D hitdata)
    {
        Debug.Log(hitdata.name);
        enemy e = hitdata.GetComponent<enemy>();

        if(e != null)
        {
            e.Takedamage(hit);
            Destroy(gameObject);

        }

        
    }



    void DestroyMe()
    {
        Destroy(transform.gameObject);
    }
}
