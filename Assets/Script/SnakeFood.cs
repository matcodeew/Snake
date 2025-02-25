using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SnakeFood : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    public List<Vector2Int> foodPos = new();

    private GridManager gridManager;
    private GameObject SpawnFood()
    {
        int posX = Random.Range(-(int)gridManager.gridWidth / 2, (int)gridManager.gridWidth / 2);
        int posY = Random.Range(-(int)gridManager.gridHeight / 2, (int)gridManager.gridHeight / 2);
        Vector3 randomPos = new Vector3(posX, posY, 0);
         
        GameObject newFood = Instantiate(foodPrefab, randomPos, Quaternion.identity);
        return newFood;
    }



}
