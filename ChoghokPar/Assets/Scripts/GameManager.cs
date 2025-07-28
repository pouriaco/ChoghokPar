using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // لیستی از GameObject‌هایی که می‌خواهید غیرفعال کنید
    public GameObject[] objectsToDisable;

    // لیستی از GameObject‌هایی که می‌خواهید فعال کنید
    public GameObject[] objectsToEnable;

    // زمین
    public GameObject groundObject;

    public GameObject treeObject;

    public MusicManager musicManager;


    public static GameManager Instance;

    [SerializeField] private GameObject _gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0f;

        // گرفتن امتیاز فعلی و بهترین امتیاز از اسکریپت ScoreScript
        int currentScore = ScoreScript.instance.GetCurrentScore();
        int bestScore = PlayerPrefs.GetInt("HighScore", 0);

        // پیدا کردن GameOverCard
        Transform gameOverCard = _gameOverPanel.transform.Find("GameOverCard");

        if (gameOverCard != null)
        {
            var currentScoreText = gameOverCard.Find("CurrentScoreText");
            var bestScoreText = gameOverCard.Find("BestScoreText");

            if (currentScoreText != null && bestScoreText != null)
            {
                currentScoreText.GetComponent<TextMeshProUGUI>().text = "CURRENT SCORE: " + currentScore.ToString();
                bestScoreText.GetComponent<TextMeshProUGUI>().text = "BEST SCORE: " + bestScore.ToString();
            }
            else
            {
                Debug.LogError("یکی از اشیاء 'CurrentScoreText' یا 'BestScoreText' پیدا نشد!");
            }
        }
        else
        {
            Debug.LogError("اشیاء 'GameOverCard' پیدا نشد!");
        }

        // پخش موزیک Game Over
        musicManager.PlayGameOverMusic();
    }

    public void Restart()
    {
        // متوقف کردن موزیک در حال پخش
        if (MusicManager.Instance != null)
        {
            MusicManager.Instance.StopMusic();
        }

        // بارگذاری دوباره صحنه‌ی فعلی
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnStartButtonPressed()
    {
        // غیرفعال کردن GameObject‌ها
        foreach (var obj in objectsToDisable)
        {
            obj.SetActive(false);
        }

        // فعال کردن GameObject‌ها
        foreach (var obj in objectsToEnable)
        {
            obj.SetActive(true);
        }

        // پیدا کردن کامپوننت LoopGround از روی GameObject زمین
        LoopGround loopGround = groundObject.GetComponent<LoopGround>();

        // اگر کامپوننت پیدا شد، مقادیر رو تنظیم کن
        if (loopGround != null)
        {
            loopGround._loopSpeed = 4.2f;
            loopGround._loopDistance = 33.5f;
        }
        else
        {
            Debug.LogWarning("کامپوننت LoopGround پیدا نشد!");
        }

        TreeMover treeMover = treeObject.GetComponent<TreeMover>();
        if (treeMover != null)
        {
            treeMover.StartMoving();
        }
    }
}
