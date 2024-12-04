using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsUIManager : MonoBehaviour
{
    public Button quitButton;

    void Start()
    {
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }

    void OnQuitButtonClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
