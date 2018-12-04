using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonScript : MonoBehaviour
{
    public Button bButton;
    void Start()
    {
        Button btn4 = bButton.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
