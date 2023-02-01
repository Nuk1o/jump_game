using System;
using UnityEngine;

public class Platform_run : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private GameObject _player;
    private int _moveDir;
    private bool _hasToMove = true;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _moveDir = transform.position.x < _player.transform.position.x ? 1 : -1;
    }

    private void Update()
    {
        if (_hasToMove==true)
        {
            transform.position += Vector3.right * _moveDir * _moveSpeed * Time.deltaTime;
        }

        if (gameObject.transform.position.y+4<_player.transform.position.y)
        {
            Destroy(gameObject);
        }
    }

    public void StopMovement() => _hasToMove = false;
}
