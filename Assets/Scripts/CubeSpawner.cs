using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cube;
    public Vector2 secondsBetwenSpawnsMinMax;
    public float spawnAngleMinMax;
    public Vector2 spawnSizeMinMax;

    float nextSpawnTime;
    Vector2 screenHalfSizeWorldUnits;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawn = Mathf.Lerp(secondsBetwenSpawnsMinMax.x, secondsBetwenSpawnsMinMax.y, Difficulty.getDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawn;

            float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
            float spawnAngle = Random.Range(-spawnAngleMinMax, spawnAngleMinMax);
            GameObject newCube = Instantiate(cube, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newCube.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
