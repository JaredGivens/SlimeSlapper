using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlapHandler : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animated_arm_animator;
    void Start()
    {
        animated_arm_animator = transform.parent.parent.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            var state_info = animated_arm_animator.GetCurrentAnimatorStateInfo(0);
            var is_arm_swinging = state_info.IsName("arm_swing");
           if (!is_arm_swinging) return;
            else
            {
                var eh = collision.gameObject.GetComponent<EntityHealth>();
                if(eh != null) { 
                eh.SendDamage(25);
                Debug.Log("slime health: " + eh.currentHealth);
                }
            }
        }
        else
        {
            Debug.Log("unknown object: " + collision.gameObject.name);
        }
    }
}
