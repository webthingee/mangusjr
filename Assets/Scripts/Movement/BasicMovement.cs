using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed; // pace of the leader and followers
    [SerializeField] private float timeBetweenMoves; // time between when moveDirection can be changed
    [SerializeField] private enum Direction { Up, Down, Right, Left } // game directions
    [SerializeField] private Direction moveDirection; // current moving direction
    [SerializeField] private Direction setDirection; // request for a give direction
    [SerializeField] private Vector3 leaderMovedAt; // Where the leader was when direction was changed
    [SerializeField] private Vector3 moveVector; // Vector3 with up, down, left or right
    Animator anim;

    void OnEnable()
    {
        moveSpeed = GetComponentInParent<MovementCtrl>().moveSpeed;
        timeBetweenMoves = GetComponentInParent<MovementCtrl>().timeBetweenMoves;
        anim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        StartCoroutine(AllowDirectionChange());
    }

    void Update()
    {
        if (transform.GetSiblingIndex() == 0)
        { // Leader
            SetDirection();
            //transform.Translate(moveVector * Time.deltaTime * moveSpeed);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + moveVector, Time.deltaTime * moveSpeed);
        }
        if (transform.GetSiblingIndex() > 0)
        { // Follower
            transform.position = Vector3.MoveTowards(transform.position, leaderMovedAt, Time.deltaTime * moveSpeed);
        }
    }

    // void OnMouseDown()
    // {
    //     if (transform.GetSiblingIndex() != transform.parent.childCount - 1)
    //     { // Don't execute on the last gameObject
    //         for (int i = transform.GetSiblingIndex(); i < transform.parent.childCount; i++)
    //         {
    //             transform.parent.GetChild(i).GetComponent<BasicMovement>().SpeedBuffStart(2f);
    //         }
    //     }
    //     Destroy(gameObject);
    // }

    void SetDirection()
    {
        float _y = Input.GetAxisRaw("Vertical");
        float _x = Input.GetAxisRaw("Horizontal");
        if (_y > 0.01f) { setDirection = Direction.Up; }
        if (_y < -0.01f) { setDirection = Direction.Down; }
        if (_x > 0.01f) { setDirection = Direction.Right; }
        if (_x < -0.01f) { setDirection = Direction.Left; }
    }

    IEnumerator AllowDirectionChange()
    {
        if (transform.GetSiblingIndex() != transform.parent.childCount - 1)
        { // Don't execute on the last gameObject
            transform.parent.GetChild(transform.GetSiblingIndex() + 1).GetComponent<BasicMovement>().leaderMovedAt = transform.position;
        }
        if (transform.GetSiblingIndex() == 0)
        { // Leader
            ExecuteDirectionChange();
        }
        yield return new WaitForSeconds(timeBetweenMoves);
        StartCoroutine(AllowDirectionChange());
    }

    void ExecuteDirectionChange()
    {
        if (setDirection == Direction.Up && moveDirection != Direction.Down)
        {
            moveDirection = setDirection;
            moveVector = Vector3.up;
            anim.SetInteger("WalkDirection", 0);
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        if (setDirection == Direction.Down && moveDirection != Direction.Up)
        {
            moveDirection = setDirection;
            moveVector = Vector3.down;
            anim.SetInteger("WalkDirection", 2);
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        if (setDirection == Direction.Right && moveDirection != Direction.Left)
        {
            moveDirection = setDirection;
            moveVector = Vector3.right;
            anim.SetInteger("WalkDirection", 1);
            GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        if (setDirection == Direction.Left && moveDirection != Direction.Right)
        {
            moveDirection = setDirection;
            moveVector = Vector3.left;
            anim.SetInteger("WalkDirection", 1);
            GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
    }

    void SpeedBuffStart(float multiplier)
    {
        moveSpeed *= multiplier;
        Invoke("SpeedBuffEnd", timeBetweenMoves * multiplier);
    }

    void SpeedBuffEnd()
    {
        moveSpeed = GetComponentInParent<MovementCtrl>().moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
