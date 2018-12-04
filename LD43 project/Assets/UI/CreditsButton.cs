using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour
{
    public Button cButton;
    void Start()
    {
        Button btn3 = cButton.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        SceneManager.LoadScene("Credits");
    }
}
