using UnityEngine;
using System.Collections;

public class ObsticleSpawner : MonoBehaviour {

    public LostMyShittyHairManager shittyHairManager;
    public GameObject columnObject;
    float timer = 0;
    public float randSpawnTimeMax = 3;
    public float randSpawnTimeMin = 1;

    // Use this for initialization
    void Start () {
       // timer = Random.Range(randSpawnTimeMin, randSpawnTimeMax);
	}
	
	// Update is called once per frame
	void Update () {
	    if (timer <= 0)
        {
            timer = Random.Range(randSpawnTimeMin, randSpawnTimeMax);
            SpawnColumn();
        }
        else
        {
            timer -= Time.deltaTime;
        }
	}

    void SpawnColumn()
    {
        GameObject column = Instantiate(columnObject, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
        column.transform.parent = gameObject.transform;
        column.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        shittyHairManager.AddScorePoint();
    }
}
