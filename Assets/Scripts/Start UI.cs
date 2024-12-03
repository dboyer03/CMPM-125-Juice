using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUIManager : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClick);
    }

    void OnStartButtonClick()
    {
        SceneManager.LoadScene("CornerScene"); 
    }
}