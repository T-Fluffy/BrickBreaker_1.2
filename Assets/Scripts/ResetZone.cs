using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ResetZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.Instance.OnBallMiss();
    }

}