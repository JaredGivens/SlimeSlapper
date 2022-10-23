using Managers;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public MenuInputReader inputReader;
    public GameObject pauseMenu, settingsMenu;

    private CameraController m_playerCamera;
    private GameObject m_player;
    private float m_pitch, m_yaw;
    private Vector3 m_eulerAngles;

    private void Awake(){
        m_player = GameObject.Find("Player");
        m_playerCamera = m_player.transform.GetChild(0).GetChild(0).GetComponent<CameraController>();
    }

    private void Update(){
        if(!GameState.isPaused)
            return;
        
        m_playerCamera.pitch = m_pitch;
        m_playerCamera.yaw = m_yaw;
        m_player.transform.eulerAngles = m_eulerAngles;
    }

	private void OnEnable()
	{
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        inputReader.pauseEvent += OnPause;
    }

    private void OnDisable()
	{
        inputReader.pauseEvent -= OnPause;
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        EnableControls(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameState.isPaused = false;
    }

    public void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        EnableControls(false);
        m_pitch = m_playerCamera.pitch;
        m_yaw = m_playerCamera.yaw;
        m_eulerAngles = m_player.transform.eulerAngles;
        
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameState.isPaused = true;
    }

    private void OnPause()
    {
        if(GameState.isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Settings()
    {
        //pauseMenu.SetActive(false);
        //settingsMenu.SetActive(true);
    }

    private void EnableControls(bool enable)
    {
        m_playerCamera.enabled = enable;
    }
    
    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
