using System.Xml.Serialization;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    
    public GameObject playButton;
    public GameObject gameOver1;
    public GameObject gameOver2;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate =60;
        gameOver1.SetActive(false);
        gameOver2.SetActive(false);
        Pause();
    }

    public void Play()
    {
        score=0;
        scoreText.text=score.ToString();

        gameOver1.SetActive(false);
        gameOver2.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled=true;

        Pipes[] pipes = FindObjectsByType<Pipes>();

        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale=0f;
        player.enabled=false;
    }
    public void GameOver()
    {
        gameOver1.SetActive(true);
        gameOver2.SetActive(true);

        playButton.SetActive(true);

        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text=score.ToString();
    }
}
