using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{

	#region Field Declarations

	[Header("UI Components")]
    [Space]
	public Text scoreText;
    public StatusText statusText;
    public Button restartButton;

    [Header("Ship Counter")]
    [SerializeField]
    [Space]
    private Image[] shipImages;

    private GameSceneController GameScene; 

    #endregion

    #region Startup

    private void Awake()
    {
        statusText.gameObject.SetActive(false);
    }

    #endregion

    #region Public methods

    private void Start()
    {
        GameScene = FindObjectOfType<GameSceneController>(); 
        GameScene.EnemyHandler += GameScene_EnemyHandler;
        GameScene.LifeLost += HideShip;
    }

    private void GameScene_EnemyHandler(int pointValue)
    {
        UpdateScore(pointValue);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString("D5");
    }

    public void ShowStatus(string newStatus)
    {
        statusText.gameObject.SetActive(true);
        StartCoroutine(statusText.ChangeStatus(newStatus));
    }

    public void HideShip(int imageIndex)
    {
        shipImages[imageIndex].gameObject.SetActive(false);
    }

    public void ResetShips()
    {
        foreach (Image ship in shipImages)
            ship.gameObject.SetActive(true);
    }

    #endregion
}
