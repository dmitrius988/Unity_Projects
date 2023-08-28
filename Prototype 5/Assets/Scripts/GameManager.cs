using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1f;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI gameOverText;
    public bool isGameOver;
    public Button restartButton;

    private int playerScore;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public static GameManager instance
    {
        get; private set;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public IEnumerator SpawnTarget()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);
            int spawnIndex = Random.Range(0, targets.Count);
            Instantiate(targets[spawnIndex]);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        textScore.text = "Score:" + playerScore;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameOver = true;

        restartButton.gameObject.SetActive(true );
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
