using UnityEngine;
using System.Collections;

public class PlayerHealth : EntityHealth
{
    [Header("Armor")]
    public float maxArmor = 200;
    public float currentArmor = 0;

    [Header("Audio")]
    public AudioClip[] audioClipArray;
    private AudioSource m_audioSource;
    private bool playOnce = true;
    private Transform camera;
    private PlayerController controller;

    public void Start(){
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.clip = audioClipArray[0];
        controller = GetComponent<PlayerController>();
        camera = controller.cameraTransform;
    }

    public void AddArmor(float armor)
    {
        currentArmor += armor;
    }

    public override void OnDeath()
    {
        if(playOnce)
            StartCoroutine("DeathSequence");
    }

    public override void ProcessDamage(float damage)
    {
        if(currentArmor < damage)
        {
            damage -= currentArmor;
            currentHealth -= damage;
            currentArmor = 0;

            if(!m_audioSource.isPlaying && currentHealth > 0)
                m_audioSource.Play();
        }
        else{
            currentArmor -= damage;
        }
            
        if(currentHealth <= 0)
        {
            OnDeath();
            currentHealth = 0;
        }
    }

    private void QuitGame(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private IEnumerator DeathSequence(){
        playOnce = false;
        controller.enabled = false;
        CameraController camController = camera.transform.GetComponent<CameraController>();
        camController.pitch = 0;
        camController.yaw = 0;
        camController.roll = 0;
        camController.enabled = false;
        camera.eulerAngles = new Vector3(0, 0 , -90.0f);
        
        m_audioSource.clip = audioClipArray[1];
        m_audioSource.Play();
        yield return new WaitWhile (()=> m_audioSource.isPlaying);
        QuitGame();
     }
}
