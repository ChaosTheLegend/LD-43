using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {
    public Button startButton;
    void Start()
    {
        Button btn1 = startButton.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene("MainGame");
    }
}
