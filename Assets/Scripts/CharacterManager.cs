using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour
{
}

public interface ICharacter
{
    void Attack();
}

public class AttackFront : MonoBehaviour, ICharacter
{
    public void Attack()
    {
        Vector3 initialPosition = new Vector3(this.transform.position.x, this.transform.position.y + 1f, 0);
        GameObject bullet = Instantiate(Resources.Load("BulletPrefab", typeof(GameObject))) as GameObject;
        bullet.transform.position = initialPosition;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 3f);
    }
}

public class AttackBack : MonoBehaviour, ICharacter
{
    public void Attack()
    {

        Vector3 initialPosition = new Vector3(this.transform.position.x, this.transform.position.y + 1f, 0);
        GameObject missile = Instantiate(Resources.Load("MissilePrefab", typeof(GameObject))) as GameObject;
        missile.transform.position = initialPosition;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 3f);

    }
}

public class AttackSpecialA : MonoBehaviour, ICharacter
{
    public void Attack()
    {

        Vector3 initialPosition = new Vector3(this.transform.position.x, this.transform.position.y + 1f, 0);
        GameObject missile = Instantiate(Resources.Load("MissilePrefab", typeof(GameObject))) as GameObject;
        missile.transform.position = initialPosition;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 3f);

    }
}

public class AttackSpecialB : MonoBehaviour, ICharacter
{
    public void Attack()
    {

        Vector3 initialPosition = new Vector3(this.transform.position.x, this.transform.position.y + 1f, 0);
        GameObject missile = Instantiate(Resources.Load("MissilePrefab", typeof(GameObject))) as GameObject;
        missile.transform.position = initialPosition;
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 3f);

    }
}

