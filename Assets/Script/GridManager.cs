using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Grid Info")]
    public int gridHeight;
    public int gridWidth;
    public int cellSize;
    public Vector2 gridOrigin;
    /*[HideInInspector]*/ public int cellCount;

    [Header("Wall")]
    [SerializeField] private GameObject _wallPrefab;

    [Header("Map Parent")]
    [SerializeField] private Transform _mapParent;

    [ContextMenu("SetGridOriginInMiddle")]
    public void SetGridOriginInMiddle()
    {
        gridOrigin = new Vector2((float)gridWidth / 2, (float)gridHeight / 2) * -1;
    }

    private void Start()
    {
        CreateVisualWall();
        CalculateCellCount();
    }

    private void CalculateCellCount()
    {
        for (int i = 0; i < gridHeight; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                cellCount++;
            }
        }
    }
    private void CreateVisualWall()
    {
        for (int x = -1; x <= gridWidth; x++)
        {
            for (int y = -1; y <= gridHeight; y++)
            {
                if (x == -1 || x == gridWidth || y == -1 || y == gridHeight)
                {
                    Vector2 pos = new Vector2(gridOrigin.x + (x * cellSize + 0.5f), gridOrigin.y + (y * cellSize + 0.5f));
                    Instantiate(_wallPrefab, pos, Quaternion.identity, _mapParent);
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        for (int x = 0; x <= gridWidth; x++)
        {
            float posX = gridOrigin.x + (x * cellSize);
            Gizmos.DrawLine(new Vector3(posX, gridOrigin.y, 0), new Vector3(posX, gridOrigin.y + gridHeight * cellSize, 0));
        }

        for (int y = 0; y <= gridHeight; y++)
        {
            float posY = gridOrigin.y + (y * cellSize);
            Gizmos.DrawLine(new Vector3(gridOrigin.x, posY, 0), new Vector3(gridOrigin.x + gridWidth * cellSize, posY, 0));
        }
    }

}
