using System;
using UnityEngine;
using UnityEngine.Events;

public class Player_controller : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private ContactFilter2D _platform;

    public UnityEvent Landed;
    public UnityEvent Dead;

    private Rigidbody2D _rigidbody2D;
    private bool _isOnPlatform => _rigidbody2D.IsTouching(_platform);

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (_isOnPlatform==true)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce,ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject collisionObject = col.gameObject;
        if (collisionObject.transform.parent != null)
        {
            if (collisionObject.transform.parent.TryGetComponent(out Platform_run platformRun))
            {
                platformRun.StopMovement();
            }
        }

        if (collisionObject.CompareTag("PlatformWall"))
        {
            Dead?.Invoke();
        }
        else if(collisionObject.CompareTag("Platform"))
        {
            collisionObject.tag = "Untagged";
            Landed?.Invoke();
        }
    }
}
