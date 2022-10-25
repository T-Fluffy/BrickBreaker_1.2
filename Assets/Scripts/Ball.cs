using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 500f;
    public new Rigidbody2D rigidbody { get; private set; }
    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        ResetBall();
    }
    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        this.rigidbody.AddForce(force.normalized * this.speed);
    }
    public void ResetBall()
    {
        Invoke(nameof(SetRandomTrajectory), 1f);
    }
}
