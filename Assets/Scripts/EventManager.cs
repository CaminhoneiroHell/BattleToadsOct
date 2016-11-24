using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour
{
    public delegate void StartGameDelegate();
    public static StartGameDelegate onStartGame;


    public delegate void TakeDamageDelegate(float amt);
    public static TakeDamageDelegate onTakeDamage;


    public static void StartGame()
    {
        Debug.Log("StartGame");
        if (onStartGame != null)
            onStartGame();
    }

    public static void TakeDamage(float percent)
    {
        Debug.Log("TakeDamage" + percent);
        if (onTakeDamage != null)
            onTakeDamage(percent);
    }
}
