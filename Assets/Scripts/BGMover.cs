using UnityEngine;
using System.Collections;

public class BGMover : MonoBehaviour
{

    [SerializeField]
    float speedMove = 2;

    Vector3 startPositionMin;
    Vector3 startPositionMax;

    [SerializeField]
    GameObject bgReference;

    void Start()
    {
        startPositionMin = bgReference.transform.position;

    }

    void Update()
    {
        transform.position += transform.right * -speedMove * Time.deltaTime;
        if (bgReference.transform.position.x <= -34f)
        {
            bgReference.transform.position = new Vector3(startPositionMax.x, startPositionMin.y, startPositionMin.z);
        }
    }
}