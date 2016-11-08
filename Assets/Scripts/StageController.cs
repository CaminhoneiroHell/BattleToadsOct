using UnityEngine;
using System.Collections;


//public enum Flame
//{
//    Blue,
//    Red
//}

public enum SpawnerType
{
    SpawnState,
    defaultState
}

public class StageController : MonoBehaviour {
    
    public GameObject spawnerCoinUp;
    public GameObject spawnerCoinDown;
    public GameObject spawnerObstacleUp;
    public GameObject spawnerObstacleDown;
    public GameObject spawnerObstacleRed;

    //Singleton
    private static StageController _instance;
    public static StageController Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        StartCoroutine("StartStateRotine");           
    }

    IEnumerator StartStateRotine()
    {
        print("Starting " + Time.time);
        yield return StartCoroutine("SummonStateRotine");
        print("Done " + Time.time);
    }

    //Blue Barrels Wave
    IEnumerator SummonStateRotine()
    {
        yield return new WaitForSeconds(5);
        spawnerObstacleDown.SetActive(true);
        spawnerObstacleUp.SetActive(true);
        spawnerCoinUp.gameObject.GetComponent<SpawnerManager>().canSpawn = false;
        spawnerCoinDown.gameObject.GetComponent<SpawnerManager>().canSpawn = false;
        print("SummonStateRotine " + Time.time);
        yield return StartCoroutine("SummonRedBarrelStateRotine");
    }

    //RedObstacle
    IEnumerator SummonRedBarrelStateRotine()
    {
        yield return new WaitForSeconds(5);
        spawnerObstacleRed.SetActive(true);
        spawnerObstacleUp.gameObject.GetComponent<SpawnerManager>().canSpawn = false;
        spawnerObstacleDown.gameObject.GetComponent<SpawnerManager>().canSpawn = false;
        print("SummonRedBarrelStateRotine " + Time.time);
        yield return StartCoroutine("SummonEnemyStateRotine");
    }

    IEnumerator SummonEnemyStateRotine()
    {
        yield return new WaitForSeconds(5);
        spawnerObstacleRed.SetActive(true);
        spawnerObstacleUp.gameObject.GetComponent<SpawnerManager>().canSpawn = false;
        spawnerObstacleDown.gameObject.GetComponent<SpawnerManager>().canSpawn = false;
        print("SummonEnemyStateRotine " + Time.time);
        //yield return StartCoroutine("SummonRotine");
    }



}

//#region variables


//public GameObject spawnerCoinUp;
//public GameObject spawnerCoinDown;
//public GameObject spawnerObstacleUp;
//public GameObject spawnerObstacleDown;
//public GameObject spawnerObstacleRed;


//public SpawnerType spawnerType;
//private ISpawn iSpawn;

//#endregion

//private void HandleSpawnType()
//{
//    Component c = gameObject.GetComponent<ISpawn>() as Component;

//    if (c != null)
//    {
//        Destroy(c);
//    }

//    #region Strategy
//    switch (spawnerType)
//    {

//        case SpawnerType.SpawnState:
//            iSpawn = gameObject.AddComponent<CoinWave>();
//            //spawnerObstacleRed.SetActive(true);
//            //iSpawn = gameObject.AddComponent<ObstacleRed>();
//            break;

//            //case SpawnerType.defaultState:
//            //iSpawn = gameObject.AddComponent<ObstacleGreen>();
//            //break;

//            //case SpawnerType.ObstacleBlue:
//            //    iSpawn = gameObject.AddComponent<ObstacleBlue>();
//            //    break;

//            //case SpawnerType.LifeCoin:
//            //    iSpawn = gameObject.AddComponent<LifeCoin>();
//            //    break;

//            //case SpawnerType.Coin:
//            //    iSpawn = gameObject.AddComponent<Coin>();
//            //    break;
//            //    }
//            #endregion
//    }
//}

////public void HandleFlameColor()
////{

////    Component c = gameObject.GetComponent<IFlame>() as Component;

////    if (c != null)
////    {
////        Destroy(c);
////        iFlame.DestroyFlame(); 
////    }

////    #region Strategy
////    switch (flameColor)
////    {

////        case Flame.Blue:
////            iFlame = gameObject.AddComponent<BlueFlame>();
////            break;

////        case Flame.Red:
////            iFlame = gameObject.AddComponent<RedFlame>();
////            break;

////        default:
////            iFlame = gameObject.AddComponent<BlueFlame>();
////            break;
//    //}
//    //  #endregion
////}

//public void SpawnBehaviour()
//{
//    //ISpawn.SpawnState();                //Defeito sei lá por que.
//}

//void Start()
//{
//    //HandleFlameColor();
//    //iFlame.ShowFlame();

//    HandleSpawnType();



//}

//void Update()
//{





//    if (Input.GetKeyDown(KeyCode.Space))
//    {
//        //  SpawnBehaviour();
//    }

//    if (Input.GetKeyDown(KeyCode.C))
//    {
//    }

//    if (Input.GetKey(KeyCode.P))
//    {
//        //spawnerType = SpawnerType.ObstacleBlue;
//    }


//    //if (Input.GetKeyDown(KeyCode.F))
//    //{
//    //    HandleFlameColor();
//    //    iFlame.ShowFlame();
//    //}


//}

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
