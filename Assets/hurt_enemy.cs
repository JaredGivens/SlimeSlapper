using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurt_enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collide");
        if(collision.gameObject.tag == "Enemy")
        {
            EntityHealth hp = collision.gameObject.GetComponent<EntityHealth>();
                Debug.Log(hp.currentHealth);
            hp.ProcessDamage(10);


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
