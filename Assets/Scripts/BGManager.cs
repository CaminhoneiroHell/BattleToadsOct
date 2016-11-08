using UnityEngine;
using System.Collections;

public class BGManager : MonoBehaviour
{
    float speedMove = 5;
    Vector3 startPositionMin;
    Vector3 startPositionMax;
    public GameObject bgReference1;
    public GameObject bgReference2;
    public GameObject bgReference3;

    void Start()
    {
       startPositionMin = bgReference1.transform.position;
       startPositionMax = bgReference3.transform.position;

    }

    void Update()
    {
        transform.Translate(-speedMove * Time.deltaTime,0,0);
        if(bgReference1.transform.position.x <= -1f)
        {
            bgReference1.transform.position = new Vector3(startPositionMax.x, startPositionMin.y, startPositionMin.z);
        }
        if (bgReference2.transform.position.x <= -1f)
        {
            bgReference2.transform.position = new Vector3(startPositionMax.x, startPositionMin.y, startPositionMin.z);
        }
        if (bgReference3.transform.position.x <= -1f)
        {
            bgReference3.transform.position = new Vector3(startPositionMax.x, startPositionMin.y, startPositionMin.z);
        }
    }
}


//float x = 10 * Mathf.Sin(Time.timeSinceLevelLoad) + startPosition.x;
//float x = 1;
//float y = startPosition.y;
//float z = startPosition.z;
//transform.position = new Vector3(x, y, z);

//transform.Translate(x * Time.deltaTime, y, z);

//    public float backGroundsize;

//    private Transform cameraTransform;
//    private Transform[] layers;
//    private float viewZone = 10;
//    private int leftIndex;
//    private int rightIndex;

//    private void Start()
//    {
//        cameraTransform = Camera.main.transform;
//        layers = new Transform[transform.childCount];
//        for (int i = 0; i < transform.childCount; i++)
//            layers[i] = transform.GetChild(i);

//        leftIndex = 0;
//        rightIndex = layers.Length - 1;
//    }

//    void Update()
//    {
//        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
//            ScrollLeft();
//        if (cameraTransform.position.x < (layers[rightIndex].transform.position.x - viewZone))
//            ScrollRight();
//    }

//    private void ScrollLeft()
//    {
//        int lastRight = rightIndex;
//        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backGroundsize);
//        leftIndex = rightIndex;
//        rightIndex--;
//        if(rightIndex < 0)
//            rightIndex = layers.Length - 1;
//    }

//    private void ScrollRight()
//    {
//        int lastLeft = leftIndex;
//        layers[leftIndex].position = Vector3.left * (layers[rightIndex].position.x - backGroundsize);
//        rightIndex = leftIndex;
//        leftIndex++;
//        if (leftIndex == layers.Length)
//            leftIndex = 0;
//    }
//}

//public GameObject bg;

//void Update()
//{
//    BgMove();
//}

//public void BgMove()
//{
//    float backgroundX = Mathf.Repeat(0, Time.time * 1);
//    Vector2 Offset = new Vector2(backgroundX, 0);
//    bg.GetComponent<SpriteRenderer>().sharedMaterial.SetTextureOffset("_MainTex", Offset);
//}