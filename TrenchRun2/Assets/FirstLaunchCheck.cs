using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaunchCheck : MonoBehaviour {

    public static bool FirstLaunch;

	// Use this for initialization
	void Start () {
		if(FirstLaunch == false)
        {
            FirstLaunch = true;
            Application.LoadLevel(1);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
