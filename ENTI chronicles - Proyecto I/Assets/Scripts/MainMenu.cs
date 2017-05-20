using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public string startlevel;
    public string actuallevel;

    public void NewGame()
    {
        Application.LoadLevel(startlevel);
    }

    public void LevelSelect()
    {
        Application.LoadLevel(actuallevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
