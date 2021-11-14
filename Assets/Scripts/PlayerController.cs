using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject headObject;
    [SerializeField] private GameObject bodyObject;
    [SerializeField] private int speed;
    private bool running = false;

    private List<GameObject> bodySegments = new List<GameObject>();

    internal void Update()
    {
        if (running) {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.AddRelativeForce(new Vector2(speed, 0));

            if (Input.GetKey(KeyCode.A)) {
                gameObject.transform.Rotate(new Vector3(0, 0, 1), 1);
            } else if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.Rotate(new Vector3(0, 0, 1), -1);
            }
        }
    }

    internal void Reset()
    {
        running = false;
        bodySegments.ForEach(segment => Destroy(segment));
    }


    internal void Run()
    {
        running = true;
    }

    internal Vector2 HeadPosition()
    {
        return headObject.transform.position;
    }

    internal void Grow()
    {
        throw new NotImplementedException();
    }
}
