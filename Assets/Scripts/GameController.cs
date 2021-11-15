using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private LevelController level;
    [SerializeField] private Text scoreObject;

    private int score = 0;

    void Start()
    {
        Reset();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Run();
        }
    }

    internal void PlayerFails()
    {
        Reset();
    }

    internal void PlayerSucceed()
    {
        SetScore(score += 100);

        player.Grow();
        level.Reset();
        level.SpawnFood();
    }

    private void Reset()
    {
        player.Reset();
        level.Reset();
        ResetScore();

        level.SpawnFood();
    }

    private void ResetScore()
    {
        score = 0;
        SetScore(score);
    }

    private void SetScore(int newScore)
    {
        scoreObject.text = newScore.ToString();
    }
}
