using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour
{
    public float velocity = -1f;
    public bool warnObject = true;

    void Start()
    {
        Destroy(this.gameObject, 10f);
    }

    void Update()
    {
        if(warnObject)
            WarnSignal();
        else
            transform.Translate(velocity * Time.deltaTime, 0, 0);
    }


    void WarnSignal()
    {
        if (transform.position.x >= 15f)
            transform.position = new Vector3(13f, transform.position.y, transform.position.z);
        else if (transform.position.x <= 13f)
            transform.position = new Vector3(15f, transform.position.y, transform.position.z);
        StartCoroutine("WarningTime");
    }

    public IEnumerator WarningTime()
    {
        yield return new WaitForSeconds(2f);
        warnObject = false;
    }
}
