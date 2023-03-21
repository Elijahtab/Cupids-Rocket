using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSwitchMainMenu : MonoBehaviour
{
    public void SwitchToMain()
    {
        SceneManager.LoadScene(1);
    }
}
