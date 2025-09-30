public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [Header("Game Settings")]
    public int totalRounds = 5;
    public float timePerRound = 120f;
    
    [Header("Current State")]
    public int currentRound = 1;
    public float currentTime;
    public int score = 0;
    public GameState gameState = GameState.Playing;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    
    void Start()
    {
        StartNewRound();
    }
    
    void Update()
    {
        if (gameState == GameState.Playing)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                EndRound();
            }
        }
    }
    
    public void StartNewRound()
    {
        currentTime = timePerRound;
        gameState = GameState.Playing;
        // Spawn new luggage
        LuggageSpawner.Instance.SpawnNewLuggage();
    }
    
    public void EndRound()
    {
        gameState = GameState.RoundEnd;
        // Show round results
        UIManager.Instance.ShowRoundResult();
        
        if (currentRound < totalRounds)
        {
            currentRound++;
            Invoke("StartNewRound", 3f);
        }
        else
        {
            GameOver();
        }
    }
    
    public void AddScore(int points)
    {
        score += points;
        UIManager.Instance.UpdateScoreUI();
    }
    
    void GameOver()
    {
        gameState = GameState.GameOver;
        UIManager.Instance.ShowGameOver();
    }
}

public enum GameState
{
    Playing,
    RoundEnd,
    GameOver
}
