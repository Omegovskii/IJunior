using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.Rigidbody.gravityScale = 0;

            if (Input.GetKey(KeyCode.W))
                player.Rigidbody.velocity = new Vector2(0, _speed);
            else if (Input.GetKey(KeyCode.S))
                player.Rigidbody.velocity = new Vector2(0, -_speed);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            player.Rigidbody.gravityScale = 1;
    }
}
