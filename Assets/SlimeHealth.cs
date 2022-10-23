using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : EntityHealth
{
    public GameObject spawn;
    static Vector3 min = new Vector3(-1, -1, -1);
    static Vector3 max = new Vector3(1, 1, 1);
    // Start is called before the first frame update
    void Start()
    {
        
    }
    override public void OnDeath()
    {

        GameObject slime;
        slime = Instantiate(spawn, transform.position +new Vector3(UnityEngine.Random.Range(min.x, max.x), 2, UnityEngine.Random.Range(min.z, max.z)), Quaternion.identity);
        slime.GetComponent<EntityHealth>().currentHealth = 100;
        slime = Instantiate(spawn, transform.position +new Vector3(UnityEngine.Random.Range(min.x, max.x), 2, UnityEngine.Random.Range(min.z, max.z)), Quaternion.identity);
        slime.GetComponent<EntityHealth>().currentHealth = 100;
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
