using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerScript : MonoBehaviour
{
 
    private bool _isGameOver = false;
    
    void Update()
    {
        if (_isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
