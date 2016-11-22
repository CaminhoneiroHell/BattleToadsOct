using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUI : MonoBehaviour
{
    bool isDisplayed = false;
    [SerializeField]
    GameObject playButton;
    [SerializeField]
    GameObject billySelectButton;
    [SerializeField]
    GameObject zitsSelectButton;

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
        //isDisplayed = !isDisplayed;
        //playButton.SetActive(isDisplayed);

        isDisplayed = !isDisplayed;
       // playButton.SetActive(isDisplayed);

        if (isDisplayed)
        {
            billySelectButton.SetActive(true);
            zitsSelectButton.SetActive(true);
            playButton.SetActive(false);
        }
        else
        {
            billySelectButton.SetActive(false);
            zitsSelectButton.SetActive(false);
            playButton.SetActive(true);
        }
    }

    public void PlayGame()
    {
        EventManager.StartGame();
    }

}
