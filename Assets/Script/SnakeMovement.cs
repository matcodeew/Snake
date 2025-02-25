using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [Header("Snake Corps")]
    [SerializeField] public Vector2Int snakeHeadPosition;
    [SerializeField] private GameObject _snakeHead;

    [SerializeField] public List<Vector2Int> snakeBodyPosition = new();
    [SerializeField] private List<GameObject> _snakeBody = new();
    [SerializeField] private GameObject _bodyPrefab;

    [Header("DirectionHandle")]
    public Vector2Int snakeDirectionHandle;

    [Header("Timer")]
    private float _timer;
    private float _snakeSpeed = 0.150f;

    [Header("Component")]
    private SnakeCollision snakeCollision;

    private void Awake()
    {
        snakeCollision = GetComponent<SnakeCollision>();
    }
    private void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        if (_timer >= _snakeSpeed)
        {
            _timer = 0;
            MoveSnake();
        }
    }
    public void SetSnakeDirection(Vector2Int direction)
    {
        if (direction == Vector2.zero) return;
        snakeDirectionHandle = direction;
    }

    [ContextMenu("AddSnakeCorpsDebug")]
    public void AddSnakeCorpsDebug()
    {
        for (int i = 0; i < _snakeBody.Count; i++)
        {
            snakeBodyPosition.Add(snakeHeadPosition);
        }
    }

    public void AddSnakeCorps()
    {
        snakeBodyPosition.Add(snakeHeadPosition);
        Vector3 headPos = new Vector3(snakeHeadPosition.x, snakeHeadPosition.y, 0);
        GameObject newBody = Instantiate(_bodyPrefab, headPos, Quaternion.identity);
    }

    private void MoveSnake()
    {
        snakeHeadPosition += snakeDirectionHandle;

        if (_snakeHead != null)
        {
            _snakeHead.transform.position = (Vector2)snakeHeadPosition;
        }

        MoveSnakeBody();
        snakeCollision.CheckCollision();
    }

    private void MoveSnakeBody()
    {
        if (snakeBodyPosition.Count > 0)
        {
            for (int i = snakeBodyPosition.Count - 1; i > 0; i--)
            {
                snakeBodyPosition[i] = snakeBodyPosition[i - 1];
                _snakeBody[i].transform.position = (Vector2)snakeBodyPosition[i];
            }

            snakeBodyPosition[0] = snakeHeadPosition - snakeDirectionHandle;
            _snakeBody[0].transform.position = (Vector2)snakeBodyPosition[0];
        }
    }
}
