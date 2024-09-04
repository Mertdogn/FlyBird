using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject[] columns;
    public GameObject columnPrefab;
    private Vector2 columnPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawn;
    private const float spawnRate = 1.5f;
    private const float columnMin = -1.8f;
    private const float columnMax = 2f;
    public float spawnXPosition = 2f;
    private int currentcolumn = 0;

    public void Start()
    {
        columns = new GameObject[columnPoolSize];

        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = Instantiate(columnPrefab, columnPoolPosition, Quaternion.identity);
            //columns[i].tag = "ScoreArea";
        }
    }

    public void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            float spawnYPosition = GetRandomFloat(columnMin, columnMax);
            Debug.Log(spawnYPosition);
            columns[currentcolumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentcolumn++;
            if (currentcolumn >= columnPoolSize)
            {
                currentcolumn = 0;
            }
        }
                
    }

    // f(x,y) = x + y
    // f(columnMin,columnMax)
    float GetRandomFloat(float min, float max)  // -2 , +2
    {
        return min + (max - min) * UnityEngine.Random.value; // Random.value 0.0 ile 1.0 arasýnda deðer döner
    }
}
