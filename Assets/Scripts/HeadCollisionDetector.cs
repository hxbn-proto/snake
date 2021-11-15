using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollisionDetector : MonoBehaviour
{
    [SerializeField] private GameController game;

    internal void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FailOnTouch"))
        {
            game.PlayerFails();
        }
        else if (collision.CompareTag("Food"))
        {
            game.PlayerSucceed();
        }
    }
}
