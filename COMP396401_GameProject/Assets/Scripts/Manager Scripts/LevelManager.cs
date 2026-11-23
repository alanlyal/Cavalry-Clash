using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Enter Game Level

    public void PlayGame()
    {
        SceneManager.LoadScene("GameLvl1");
        Debug.Log("Entered GameLvl1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Entered MainMenu");
    }

}
