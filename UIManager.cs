public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    [Header("VR UI Elements")]
    public Canvas vrCanvas;
    public Text timerText;
    public Text scoreText;
    public Text roundText;
    public GameObject scanningPanel;
    public GameObject resultPanel;
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    
    public void UpdateTimerUI(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    public void UpdateScoreUI()
    {
        scoreText.text = "Score: " + GameManager.Instance.score;
    }
    
    public void ShowScanningUI(bool show)
    {
        scanningPanel.SetActive(show);
    }
    
    public void DisplayScanResult(Luggage luggage, List<ProhibitedItem> foundItems)
    {
        // Display scan results
        resultPanel.SetActive(true);
        
        // Update result UI
        // ...
    }
}
