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
    public float spawnRate = 1f;
    public float columnMin = -1.5f;
    public float columnMax = 2.5f;
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
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentcolumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentcolumn++;
            if (currentcolumn >= columnPoolSize)
            {
                currentcolumn = 0;
            }
        }
    }
}
