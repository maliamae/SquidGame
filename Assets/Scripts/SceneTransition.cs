using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int targetScene;
    public void ChangeScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}
