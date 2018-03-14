using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class splashScreene : MonoBehaviour {

    public string sceneToLoad;

    public int secondsTillSceneLoads;

	// Use this for initialization
	void Start () {

        Invoke("OpenNextScene", secondsTillSceneLoads);

	}
	
	void OpenNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
