
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    
    public GameObject[] meteorsPrefab;
    private Vector2 screeWordSizeWorldUnits ;
    private Vector2 secondsBtwSpawnMinMax = new Vector2(0.4f,0.8f);
    private float nextSpawnTime;
    private Vector2 spawnSizeMinMax = new Vector2(0.8f, 2.7f);
    private float maxSpawnAngle = 15f;
    
    
    
    
    
    void Start()
    {
        screeWordSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize , Camera.main.orthographicSize );
    }

    
    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBtwSpawnMinMax.y,
                secondsBtwSpawnMinMax.x,
                DifficulityManager.GetDifficultyPercent());
            nextSpawnTime = Time.timeSinceLevelLoad + secondsBetweenSpawns;
            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            float spawnAngle = Random.Range(-maxSpawnAngle, maxSpawnAngle);
            Vector2 spawnPosition = new Vector2()
            {
                x = Random.Range(-screeWordSizeWorldUnits.x, screeWordSizeWorldUnits.x),
                y = screeWordSizeWorldUnits.y + spawnSize 
            };
            GameObject newMeteor = Instantiate(GetRandomMeteor(meteorsPrefab),spawnPosition, Quaternion.Euler(Vector3.forward*spawnAngle));
            newMeteor.transform.localScale = Vector2.one * spawnSize;


        }
        
    }

    private GameObject GetRandomMeteor(GameObject[] meteros)
    {
        return meteros[Random.Range(0, meteros.Length)];
    }
   

    
}
