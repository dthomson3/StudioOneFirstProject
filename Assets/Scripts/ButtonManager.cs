using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour {

    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void Pause(string _sceneName)
    {
        Time.timeScale = 0;
        SceneManager.LoadSceneAsync(_sceneName,LoadSceneMode.Additive);
    }
}
