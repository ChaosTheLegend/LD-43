using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {
    public Button pauseButton;
    public GameObject pauseMenu;
    void Start()
    {
        Button btn1 = pauseButton.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        Time.timeScale = 0;
        Instantiate(pauseMenu, new Vector3 (0,0,0), new Quaternion(0, 0, 0, 1));
    }
}
