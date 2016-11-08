using UnityEngine;

public class SceneManager
{
}
    public interface ISpawn{
      void SpawnState();
    }

    public class CoinWave : MonoBehaviour, ISpawn
    {
        public void SpawnState()
        {
        Vector3 initialPosition = new Vector3(this.transform.position.x + 1f, this.transform.position.y, 0);
        GameObject obstacleRed = Instantiate(Resources.Load("ObstacleRed", typeof(GameObject))) as GameObject;
        obstacleRed.transform.position = initialPosition;
        obstacleRed.GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, 0);
        //spawner.SetActive(active);

        Debug.Log("To na interface");
        }
    }

