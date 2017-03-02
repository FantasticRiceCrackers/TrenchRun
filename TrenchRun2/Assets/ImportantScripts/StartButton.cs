using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SceneManagement;
using UnityEngine;

public class StartButton : MonoBehaviour {
	
	public void ChangeToScene (int sceneToChangeTo)
    {
        Application.LoadLevel(sceneToChangeTo);
	}

    public void ExitGame()
    {
        Application.Quit();
    }


}