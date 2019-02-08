using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void LoadNextScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadPlayScreen()
    {
        SceneManager.LoadScene("PlayScreen");
    }

}
