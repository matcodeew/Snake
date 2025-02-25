using UnityEngine;

public class SnakeCollision : MonoBehaviour
{
    [SerializeField] private SnakeMovement _snakeMovement;
    [SerializeField] private SnakeFood _snakeFood;
    [SerializeField] private GridManager _grid;

    public void CheckCollision()
    {
        CheckWallCollision();
        CheckSnakeBodyCollision();
    }

    private void CheckFoodCollision()
    {
        for (int i = 0; i < _snakeFood.foodPos.Count; i++)
        {
            if (_snakeMovement.snakeHeadPosition == _snakeFood.foodPos[i])
            {
                _snakeMovement.AddSnakeCorps();
            }
        }
    }
    private void CheckSnakeBodyCollision()
    {
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
        if (_snakeMovement.snakeHeadPosition.x >= (int)_grid.gridWidth / 2)
        {
            GameOver();
        }
        else if (_snakeMovement.snakeHeadPosition.x <= -(int)_grid.gridWidth / 2)
        {
            GameOver();
        }
        else if (_snakeMovement.snakeHeadPosition.y >= (int)_grid.gridHeight / 2)
        {
            GameOver();
        }
        else if (_snakeMovement.snakeHeadPosition.y <= -(int)_grid.gridHeight / 2)
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        print("GameOver");

    }
}
