using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public float offsetY;
    public float centerWidth;

    float _pX;
    float _pY;

    void Start ()
    {
        float _pX = transform.position.x;
        float _pY = transform.position.y;
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
    void Update ()
    {
        if (player) {
            if (player.position.x > transform.position.x + centerWidth)
            {
                _pX = player.position.x - centerWidth;
            }
            if (player.position.x < transform.position.x - centerWidth)
            {
                _pX = player.position.x + centerWidth;
            }
            if (player.position.y > transform.position.y + centerWidth)
            {
                _pY = player.position.y - centerWidth;
            }
            if (player.position.y < transform.position.y - centerWidth)
            {
                _pY = player.position.y + centerWidth;
            }

            // execute
            transform.position = new Vector3(_pX, _pY, transform.position.z);
        }
    }
}
