using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour {

    public string firstLevel;
    public void NewGame() {
        Application.LoadLevel(firstLevel);
    }

    public void ExitGame (){
        Application.Quit();    
    }
}
