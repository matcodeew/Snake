using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridManager))]
public class SnakeFood : MonoBehaviour
{
    [Header("Needed Component")]
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private EndGame _endGame;


    private GridManager _gridManager;
    [HideInInspector] public List<Vector2Int> foodPos = new();
    [HideInInspector] public List<GameObject> foods = new();

    private void Awake()
    {
        _gridManager = GetComponent<GridManager>();
    }
    private void Start()
    {
        SpawnFood();
    }

    public void SpawnFood(SnakeMovement snakeMovement = null)
    {
        #region Check Free spaces in grid

        List<Vector2Int> freeSpaces = new List<Vector2Int>();

        for (int x = -_gridManager.gridWidth / 2; x < _gridManager.gridWidth / 2; x++)
        {
            for (int y = -_gridManager.gridHeight / 2; y < _gridManager.gridHeight / 2; y++)
            {
                Vector2Int pos = new Vector2Int(x, y);

                if (snakeMovement != null &&
                    (snakeMovement.snakeBodyPosition.Contains(pos) || pos == snakeMovement.snakeHeadPosition))
                {
                    continue;
                }

                freeSpaces.Add(pos);
            }
        }

        #endregion

        #region End Game Victory Condition

        if (freeSpaces.Count == 0)
        {
            Debug.Log("Plus d'espace pour spawn de la nourriture !");
            _endGame.Victory();
            return;
        }

        #endregion

        Vector2Int randomPosInt = freeSpaces[Random.Range(0, freeSpaces.Count)];
        Vector3 randomPos = new Vector3(randomPosInt.x, randomPosInt.y, 0);

        GameObject newFood = Instantiate(foodPrefab, randomPos, Quaternion.identity);
        foodPos.Add(randomPosInt);
        foods.Add(newFood);
    }


    public void DestroyFood(int index)
    {
        Destroy(foods[index]);
        foods.Remove(foods[index]);
        foodPos.Remove(foodPos[index]);
    }
}
