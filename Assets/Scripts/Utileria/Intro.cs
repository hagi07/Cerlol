using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
        if (Application.loadedLevelName == "Intro" && Input.anyKeyDown)
            Application.LoadLevel("Principal");
	}
}
