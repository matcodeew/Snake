using UnityEngine;


public class SnakeCollision : MonoBehaviour
{
    [Header("RequireComponent of Snake")]
    [SerializeField] private SnakeMovement _snakeMovement;

    [Header("RequireComponent of Manager")]
    [SerializeField] private SnakeFood _snakeFood;
    [SerializeField] private GridManager _grid;
    [SerializeField] private EndGame _endGame;


    public void CheckCollision()
    {
        CheckWallCollision();
        CheckSnakeBodyCollision();
        CheckFoodCollision();
    }

    private void CheckFoodCollision()
    {
        if (_snakeFood.foodPos.Count <= 0) { return; }

        for (int i = 0; i < _snakeFood.foodPos.Count; i++)
        {
            if (_snakeMovement.snakeHeadPosition == _snakeFood.foodPos[i])
            {
                _snakeFood.DestroyFood(i);
                _snakeMovement.AddSnakeCorps();
                _snakeFood.SpawnFood(_snakeMovement);
                return;
            }
        }
    }
    private void CheckSnakeBodyCollision()
    {
        if (_snakeMovement.snakeBodyPosition.Count <= 0) { return; }

        for (int i = 0; i < _snakeMovement.snakeBodyPosition.Count; i++)
        {
            if (_snakeMovement.snakeHeadPosition == _snakeMovement.snakeBodyPosition[i])
            {
                GameOver();
            }
        }
    }
    private void CheckWallCollision()
    {
        if (_snakeMovement.snakeHeadPosition.x >= (int)_grid.gridWidth / 2 + 1)
        {
            GameOver();
        }
        else if (_snakeMovement.snakeHeadPosition.x <= -(int)_grid.gridWidth / 2 - 1)
        {
            GameOver();
        }
        else if (_snakeMovement.snakeHeadPosition.y >= (int)_grid.gridHeight / 2 + 1)
        {
            GameOver();
        }
        else if (_snakeMovement.snakeHeadPosition.y <= -(int)_grid.gridHeight / 2 - 1)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        _endGame.GameOver();
    }
}
