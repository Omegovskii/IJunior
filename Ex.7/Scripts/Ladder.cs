using UnityEngine;

public class Ladder : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 0;

            if (Input.GetKey(KeyCode.W))
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, _speed);
            else if (Input.GetKey(KeyCode.S))
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -_speed);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
