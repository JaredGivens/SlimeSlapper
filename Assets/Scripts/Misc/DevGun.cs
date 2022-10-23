using Managers;
using UnityEngine;

public class DevGun : MonoBehaviour
{
    public float maxDistance = 1000f;
    private Camera cam;
    public LayerMask ignoreMask;
    public GameObject prefab;
    private Animator animator;

    private AudioSource mAudioSource;
    private float og_pitch;
    private void Start()
    {
        cam = transform.parent.parent.GetComponent<Camera>();
        animator = GetComponent<Animator>();
        mAudioSource = GetComponent<AudioSource>();
        og_pitch = mAudioSource.pitch;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.Play("base.arm_swing");
            mAudioSource.pitch = Random.Range(-0.35f, 0.35f) + og_pitch; 
            mAudioSource.Play();
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, maxDistance, ignoreMask))
            {
                //FireImpulse(hit);
                FireBullets(hit);
            }
        }
    }
    
    public void FireBullets(RaycastHit hit)
    {
        if(hit.transform.gameObject.name == "Slime")
        {
            EntityHealth hp = hit.transform.GetComponent<SlimeHealth>();
            if (hp)
            {
                hp.SendDamage(25);
                Debug.Log("Doing 25 damage to slime. New slime health: " + hp);
            }
        }
    }

    public void FireImpulse(RaycastHit hit)
    {
        Instantiate(prefab, hit.point, Quaternion.identity);
    }
}
