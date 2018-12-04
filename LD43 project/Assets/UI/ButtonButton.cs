using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class ButtonButton : MonoBehaviour
{
    public Button gButton;
    void Start()
    {
        Button btn2 = gButton.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene("TestingScene");
    }
}
