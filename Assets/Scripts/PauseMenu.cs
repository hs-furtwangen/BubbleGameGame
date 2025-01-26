using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject playerScript;
    public GameObject pauseMenu;
     public FirstPersonController FPSController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TogglePause(){
        pauseMenu.SetActive(false);
        playerScript.GetComponent<Player>().isPaused = false;
        FPSController.playerCanMove = true;
        FPSController.enableJump = true;
        FPSController.cameraCanMove = true;
        FPSController.lockCursor = true;
    }

    public void BackToTitle(){
        SceneManager.LoadScene(0);
    }
}
