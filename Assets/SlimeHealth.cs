using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeHealth : EntityHealth
{
    public int max_slimes = 512;
    private bool died;
    public GameObject spawn;
    static Vector3 min = new Vector3(-1, -1, -1);
    static Vector3 max = new Vector3(1, 1, 1);
    private AudioSource squash;
    static int amt;
    // Start is called before the first frame update
    void Start()
    {
        ++amt;
        if(amt == max_slimes)
        {
            
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        }
        squash = GetComponent<AudioSource>();
        squash.Stop();
    }
    override public void OnDeath()
    {
        GameObject slime;
        slime = Instantiate(spawn, transform.position +new Vector3(UnityEngine.Random.Range(min.x, max.x), 2, UnityEngine.Random.Range(min.z, max.z)), Quaternion.identity);
        slime.GetComponent<EntityHealth>().currentHealth = 100;
        currentHealth = 100;
        StartCoroutine(PlayDeath());
    }

    private IEnumerator PlayDeath()
    {
    
        squash.Play();
        yield return new WaitForSeconds(squash.clip.length);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
