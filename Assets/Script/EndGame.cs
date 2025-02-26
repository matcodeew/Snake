using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _victoryPanel;
    private GridManager _gridManager;

    private void Awake()
    {
        _gridManager = GetComponent<GridManager>();
    }
    public void GameOver()
    {
        Time.timeScale = 0.0f;
        _gameOverPanel.SetActive(true);
    }
    public void Victory()
    {
        Time.timeScale = 0.0f;
        _victoryPanel.SetActive(true);
    }
}
