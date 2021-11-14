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
        if (Input.GetKeyDown(KeyCode.Space)) {
            player.Run();
        }
    }

    internal void PlayerFails() {
        Reset();
    }

    internal void PlayerSucceed() {
        player.Grow();
        level.Reset();
    }

    private void Reset()
    {
        player.Reset();
        level.Reset();
        ResetScore();

        level.SpawnFood(player.HeadPosition());
    }

    private void ResetScore()
    {
        SetScore(0);
    }

    private void SetScore(int newScore)
    {
        scoreObject.text = newScore.ToString();
    }
}
