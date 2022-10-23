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
        if(collision.gameObject.tag == "Enemy")
        {
            EntityHealth hp = collision.gameObject.GetComponent<EntityHealth>();
            hp.ProcessDamage(10);


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
