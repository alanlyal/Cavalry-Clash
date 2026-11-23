using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    //Enter Game Level
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameLvl1");
        Debug.Log("Entered GameLvl1");
    }
}
