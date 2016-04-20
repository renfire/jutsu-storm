using UnityEngine;
using System.Collections;

public class NinjaSpawnController : MonoBehaviour {

    public GameObject SubCerdo;
    public int numberSpawns = 5;
    public GameObject[] SubCerdoCreated;

    private float nextSpawn;
    private bool spawn = true;
    // Use this for initialization
    void Start () {
        nextTimeSpawn(2);
    }
    void Update() {

        if (spawn && nextSpawn<=Time.time) {
            spawn = false;
            numberSpawns--;
            GameObject clone = Instantiate(SubCerdo, transform.position, transform.rotation) as GameObject;
            clone.GetComponent<EnemyController>().myCreator = gameObject;
            SubCerdoCreated = new GameObject[1];
            SubCerdoCreated[0] = clone;
        }

    }

    public void killEnemy() {
        
        Destroy(SubCerdoCreated[0], 3);

        if (numberSpawns > 0)
        {
            spawn = true;
            nextTimeSpawn(5);
        }

    }

    void nextTimeSpawn(float delay)
    {
        nextSpawn = Time.time + delay;
    }
}
