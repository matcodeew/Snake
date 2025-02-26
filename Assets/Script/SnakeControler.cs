using UnityEngine;

public class SnakeControler : MonoBehaviour
{
    [Header("RequireComponent of Snake")]
    [SerializeField] private SnakeMovement _snakeMovement;


    private Vector2Int _previousDirection = Vector2Int.zero;
    private void Update()
    {
        Vector2Int dir = _previousDirection;

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && _previousDirection != Vector2Int.down)
        {
            dir = Vector2Int.up;
        }
        else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && _previousDirection != Vector2Int.up)
        {
            dir = Vector2Int.down;
        }
        else if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && _previousDirection != Vector2Int.right)
        {
            dir = Vector2Int.left;
        }
        else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && _previousDirection != Vector2Int.left)
        {
            dir = Vector2Int.right;
        }

        if (dir != _previousDirection)
        {
            _previousDirection = dir;
            _snakeMovement.SetSnakeDirection(dir);
        }
    }
}
