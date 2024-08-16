using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [Header("Setting GameOver")]
    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        Time.timeScale = 1;
        _gameOverPanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("Ground"))
        {
            _gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
