using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endingManager : MonoBehaviour
{
    public Button restartButton;
    // Start is called before the first frame update
    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("escape")){
            Application.Quit();
        }
        // UpdateLevel();
    }

    public void RestartGame(){
        SceneManager.LoadScene("SampleScene");

    }
}
