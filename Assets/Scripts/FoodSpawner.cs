using System;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private float spawnBounds;

    internal GameObject spawnFood(Vector2 avoidLocation)
    {
        float maxCoord = spawnBounds;
        float minCoord = spawnBounds * -1;

        float selectedXpos = UnityEngine.Random.Range(minCoord, maxCoord);
        float selectedYpos = UnityEngine.Random.Range(minCoord, maxCoord);

        return Instantiate(food, new Vector2(selectedXpos, selectedYpos), Quaternion.identity);
    }
}
