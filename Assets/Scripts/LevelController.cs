using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private FoodSpawner foodSpawner;
    private List<GameObject> food = new List<GameObject>();

    internal void SpawnFood()
    {
        food.Add(foodSpawner.spawnFood());
    }

    internal void Reset()
    {
        food.ForEach(food => Destroy(food));
    }
}
