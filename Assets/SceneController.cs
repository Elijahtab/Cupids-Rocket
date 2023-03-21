using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private ScoreController scoreController;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreController.score > 50)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void SwitchToMain()
    {
        SceneManager.LoadScene(1);
    }
}
