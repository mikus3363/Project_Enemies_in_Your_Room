using System.Diagnostics;
using TMPro;
using UnityEngine;

public class GameStartUI : MonoBehaviour
{
    [Header("UI References")]
    public GameObject hudStart;
    public GameObject hudScore;
    public GameObject infoScore;
    public TextMeshProUGUI scoreText;
    public GameObject winText;
    public GameObject restartButton;

    [Header("Gameplay")]
    public GameObject zombieSpawner;

    private int score = 0;
    private bool gameEnded = false;

    void Start()
    {
        ShowStartUI();
    }

    public void AddPoints(int amount)
    {
        if (gameEnded) return;

        score += amount;
        UpdateScoreUI();

        if (score >= 2400)
        {
            EndGame();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"Punkty: {score}";
    }

    void EndGame()
    {
        gameEnded = true;

        if (zombieSpawner != null)
            zombieSpawner.SetActive(false);

        if (hudScore != null)
            hudScore.SetActive(true); // t�o HUD zostaje

        if (scoreText != null)
            scoreText.gameObject.SetActive(false); // znika

        if (infoScore != null)
            infoScore.SetActive(false); // znika

        if (winText != null)
            winText.SetActive(true); // pojawia si�

        if (restartButton != null)
            restartButton.SetActive(true); // pojawia si�

        Zombie[] allZombies = FindObjectsOfType<Zombie>();
        foreach (Zombie z in allZombies)
            Destroy(z.gameObject);
    }

    public void StartGame()
    {
        ShowStartUI(); // wraca do stanu pocz�tkowego
    }

    void ShowStartUI()
    {
        score = 0;
        gameEnded = false;

        if (zombieSpawner != null)
            zombieSpawner.SetActive(false);

        if (hudStart != null)
            hudStart.SetActive(true);

        if (hudScore != null)
            hudScore.SetActive(false);

        if (scoreText != null)
        {
            scoreText.text = "Punkty: 0";
            scoreText.gameObject.SetActive(true);
        }

        if (infoScore != null)
            infoScore.SetActive(true);

        if (winText != null)
            winText.SetActive(false);

        if (restartButton != null)
            restartButton.SetActive(false);
    }

    // Wywo�uje si� po klikni�ciu �Zagraj� na HUD_Start
    public void BeginGameplay()
    {
        if (hudStart != null)
            hudStart.SetActive(false);

        if (hudScore != null)
            hudScore.SetActive(true);

        if (zombieSpawner != null)
            zombieSpawner.SetActive(true);

        if (scoreText != null)
        {
            scoreText.text = "Punkty: 0";
            scoreText.gameObject.SetActive(true);
        }

        if (infoScore != null)
            infoScore.SetActive(true);

        if (winText != null)
            winText.SetActive(false);

        if (restartButton != null)
            restartButton.SetActive(false);

        score = 0;
        gameEnded = false;
    }
}
