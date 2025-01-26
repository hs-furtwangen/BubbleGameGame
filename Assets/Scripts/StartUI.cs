using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public GameObject startmenu;
    public GameObject howToMenu;
    public GameObject creditsMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartBubbleGame(){
        SceneManager.LoadScene(1);
    }

    public void QuitBubbleGame(){
        Application.Quit();
    }

    public void OpenCredits(){
        startmenu.SetActive(false);
        howToMenu.SetActive(true);
        creditsMenu.SetActive(true);
    }

    public void OpenHowTo(){
        startmenu.SetActive(false);
        howToMenu.SetActive(true);
        creditsMenu.SetActive(true);
    }

    public void OpenStartmenu(){
        startmenu.SetActive(true);
        howToMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
}
