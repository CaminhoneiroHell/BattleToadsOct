using UnityEngine;
using System.Collections;

public class LifeUI : MonoBehaviour
{
    [SerializeField]
    RectTransform barRectTransform;
    float maxWidth;

    void Awake()
    {
        maxWidth = barRectTransform.rect.width;
    }

    void OnEnable()
    {
        EventManager.onTakeDamage += UpdateShieldDisplay;
    }

    void OnDisable()
    {
        EventManager.onTakeDamage -= UpdateShieldDisplay;
    }


    void UpdateShieldDisplay(float percentage)
    {
        barRectTransform.sizeDelta = new Vector2(maxWidth * percentage, 10f);
    }
}

/*  LifeUITeste
    [SerializeField]
    RectTransform barRectTransform;
    float maxWidth;

    void Awake()
    {
        maxWidth = barRectTransform.rect.width;
    }

    void OnEnable()
    {
        EventManager.onTakeDamage += UpdateShieldDisplay;
    }

    void OnDisable()
    {
        EventManager.onTakeDamage -= UpdateShieldDisplay;
    }


    void UpdateShieldDisplay(float percentage)
    {
        barRectTransform.sizeDelta = new Vector2(maxWidth * percentage, 10f);
    }
*/