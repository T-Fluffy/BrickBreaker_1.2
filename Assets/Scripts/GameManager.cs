using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Brick[] bricks { get; private set; }
    public int level = 1;
    public int score = 0;
    public int lives = 3;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    private void Start()
    {
        NewGame();
    }
    public void NewGame()
    {
        this.score = 0;
        this.lives = 1;
        LoadLevel(1);
    }
    public void LoadLevel(int lvl)
    {
        this.level = lvl;
        SceneManager.LoadScene("Level" + lvl);
    }
    public void Hit(Brick brick)
    {
        this.score += brick.points;

        if (ClearedLvl())
        {
            LoadLevel(this.level + 1);
        }
    }
    private bool ClearedLvl()
    {
        for (int i = 0; i < this.bricks.Length; i++)
        {
            if (this.bricks[i].gameObject.activeInHierarchy && !this.bricks[i].unbreakable)
            {
                return false;
            }
        }
        return true;
    }
    public void Miss()
    {
        this.lives--;
        if (this.lives > 0)
        {
            ResetLevels();
        }
        else
        {
            GameOver();
        }
    }
    public void ResetLevels()
    {
        this.ball.ResetBall();
        this.paddle.ResetPaddle();
        /*for (int i = 0; i < this.bricks.Length; i++)
        {
            this.bricks[i].ResetBricks();
        }*/
    }
    public void GameOver()
    {
        NewGame();
    }
    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
        this.bricks = FindObjectsOfType<Brick>();
    }
}
