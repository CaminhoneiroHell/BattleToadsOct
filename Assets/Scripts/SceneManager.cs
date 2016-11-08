using UnityEngine;

public class SceneManager
{
}
    public interface ISpawn{
        void Spawn(GameObject spawner,bool active);
    }

    public class ObstacleRed : MonoBehaviour, ISpawn
    {
        public void Spawn(GameObject spawner, bool active)
        {
            //Vector3 initialPosition = new Vector3(this.transform.position.x + 1f, this.transform.position.y, 0 );
            //GameObject obstacleRed = Instantiate(Resources.Load("ObstacleRed", typeof(GameObject))) as GameObject;
            //obstacleRed.transform.position = initialPosition;
            //obstacleRed.GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, 0);
            spawner.SetActive(active);
        }
    }

