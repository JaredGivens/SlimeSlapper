using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime_collide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
