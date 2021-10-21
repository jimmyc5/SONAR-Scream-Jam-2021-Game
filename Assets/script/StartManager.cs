using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("escape")){
            Application.Quit();
        }
        // UpdateLevel();
    }

    public void StartGame(){
        SceneManager.LoadScene("SampleScene");

    }
}
