using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFrameRate : MonoBehaviour {

    private void Update()
    {
        Application.targetFrameRate = 30;
    }
}
