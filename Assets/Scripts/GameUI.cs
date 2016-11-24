using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUI : MonoBehaviour
{
    bool isDisplayed = true;
    [SerializeField]
    GameObject playButton;

    void OnEnable()
    {
        EventManager.onStartGame += HidePanel;
    }

    void OnDisable()
    {
        EventManager.onStartGame -= HidePanel;
    }

    void HidePanel()
    {
        isDisplayed = !isDisplayed;
        playButton.SetActive(isDisplayed);
    }
    
    public void PlayGame()
    {
        EventManager.StartGame();
    }
}
