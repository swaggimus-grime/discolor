using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int sceneNum) {
        SceneManager.LoadScene(sceneNum);
    }

    public void Quit() {
        Application.Quit();
    }
}
