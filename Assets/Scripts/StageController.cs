﻿using UnityEngine;
using System.Collections;

public enum SpawnerType
{
    ObstacleRed,
    ObstacleBlue,
    ObstacleGreen,
    Coin,
    LifeCoin
}

//public enum Flame
//{
//    Blue,
//    Red
//}

public class StageController : MonoBehaviour {

    #region variables


    public GameObject spawnerCoinUp;
    public GameObject spawnerCoinDown;
    public GameObject spawnerObstacleUp;
    public GameObject spawnerObstacleDown;
    public GameObject spawnerObstacleRed;


    public SpawnerType spawnerType;

    private ISpawn iSpawn;
    #endregion

    private void HandleSpawnType()
    {
        Component c = gameObject.GetComponent<ISpawn>() as Component;

        if (c != null)
        {
            Destroy(c);
        }

        #region Strategy
        switch (spawnerType)
        {

            case SpawnerType.ObstacleRed:
                iSpawn = gameObject.AddComponent<ObstacleRed>();
                break;

                //case SpawnerType.ObstacleGreen:
                //    iSpawn = gameObject.AddComponent<ObstacleGreen>();
                //    break;

                //case SpawnerType.ObstacleBlue:
                //    iSpawn = gameObject.AddComponent<ObstacleBlue>();
                //    break;

                //case SpawnerType.LifeCoin:
                //    iSpawn = gameObject.AddComponent<LifeCoin>();
                //    break;

                //case SpawnerType.Coin:
                //    iSpawn = gameObject.AddComponent<Coin>();
                //    break;
        }
        #endregion
    }

    //public void HandleFlameColor()
    //{

    //    Component c = gameObject.GetComponent<IFlame>() as Component;

    //    if (c != null)
    //    {
    //        Destroy(c);
    //        iFlame.DestroyFlame(); 
    //    }

    //    #region Strategy
    //    switch (flameColor)
    //    {

    //        case Flame.Blue:
    //            iFlame = gameObject.AddComponent<BlueFlame>();
    //            break;

    //        case Flame.Red:
    //            iFlame = gameObject.AddComponent<RedFlame>();
    //            break;

    //        default:
    //            iFlame = gameObject.AddComponent<BlueFlame>();
    //            break;
    //    }
    //      #endregion
    //}

    public void SpawnBehaviour()
    {
        iSpawn.Spawn(spawnerObstacleRed, true);
    }

    void Start()
    {

        //HandleFlameColor();
        //iFlame.ShowFlame();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
          //  SpawnBehaviour();
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
        }

        if(Input.GetKey(KeyCode.P))
        {
            spawnerType = SpawnerType.ObstacleBlue;
        }


        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    HandleFlameColor();
        //    iFlame.ShowFlame();
        //}


    }

    //IEnumerator SummonRotine()
    //{
    //    spawnerType = SpawnerType.ObstacleBlue;
    //    // suspend execution for 5 seconds
    //    yield return new WaitForSeconds(5);
    //    print("SummonRotine " + Time.time);
    //}

    //IEnumerator StartRotine()
    //{
    //    print("Starting " + Time.time);
    //    spawnerType = SpawnerType.ObstacleBlue;

    //    // Start function WaitAndPrint as a coroutine
    //    yield return StartCoroutine("SummonRotine");
    //    print("Done " + Time.time);
    //}


    /*FastTags
    Ground
    Obstacle
    Enemy
    Item
    Attack
    */

    //private void OnTriggerEnter2D(Collider2D c)
    //{
    //    if (c.tag == "Coin")
    //    {
    //        Debug.Log(c.tag);
    //        spawnerType = SpawnerType.ObstacleBlue;
    //    }
    //    if (c.tag == "Obstacle")
    //    {
    //        spawnerType = SpawnerType.ObstacleRed;
    //        Debug.Log(c.tag);
    //    }
    //    if (c.tag == "Item")
    //    {
    //        spawnerType = SpawnerType.ObstacleGreen;
    //        Debug.Log(c.tag);
    //    }
    //}



}
