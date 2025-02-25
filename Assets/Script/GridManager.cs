using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Grid Info")]
    public int gridHeight;
    public int gridWidth;
    public int cellSize;
    public Vector2 gridOrigin;

    [ContextMenu("SetGridOriginInMiddle")]
    public void SetGridOriginInMiddle()
    {
        gridOrigin = new Vector2((float)gridWidth / 2, (float)gridHeight / 2) * -1;
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
