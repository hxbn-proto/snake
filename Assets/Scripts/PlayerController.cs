using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject headObject;
    [SerializeField] private GameObject bodyObject;
    public float acceleration;
    public float accelerationGrowCoef;
    public float steering;

    private float speed;
    private bool running = false;

    private Rigidbody2D rb;
    private List<GameObject> bodySegments = new List<GameObject>();

    internal void Start()
    {
        rb = headObject.GetComponent<Rigidbody2D>();
    }

    internal void Update()
    {
        if (running)
        {
            rb = headObject.GetComponent<Rigidbody2D>();
            float h = -Input.GetAxis("Horizontal");

            rb.angularVelocity = h * steering * 100;
            rb.velocity = speed * rb.transform.right;

            // Debug:
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                Grow();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                ResetObj();
            }*/
        }
    }

    internal void Reset()
    {
        running = false;

        bodySegments.ForEach(segment => Destroy(segment));
        bodySegments = new List<GameObject>();
        rb.velocity = rb.position = new Vector2();
        rb.rotation = rb.angularVelocity = 0;
        speed = acceleration;
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
        GameObject jointTarget = bodySegments.Count == 0 ? headObject : bodySegments[bodySegments.Count - 1];

        GameObject body = Instantiate(bodyObject, jointTarget.transform.position, jointTarget.transform.rotation);
        bodySegments.Add(body);

        DistanceJoint2D joint = body.AddComponent<DistanceJoint2D>();
        Rigidbody2D rbd = body.GetComponent<Rigidbody2D>();
        rbd.gravityScale = 0;
        rbd.drag = 100;

        joint.autoConfigureDistance = false;
        joint.distance = 0.5f;
        joint.maxDistanceOnly = true;

        joint.connectedBody = jointTarget.GetComponent<Rigidbody2D>();

        speed += accelerationGrowCoef;
    }
}
