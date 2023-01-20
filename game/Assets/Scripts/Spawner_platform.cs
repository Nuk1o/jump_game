using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner_platform : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _platformPref;
    [SerializeField] private float _verticalOffset = 0.5f;

    private float? _lastPointPosY = null;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        Transform randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
        float spawnPointPositionY = _lastPointPosY == null
            ? randomSpawnPoint.position.y
            : (float)_lastPointPosY + _verticalOffset;

        randomSpawnPoint.position = new Vector3(randomSpawnPoint.position.x, spawnPointPositionY, randomSpawnPoint.position.z);
        _lastPointPosY = spawnPointPositionY;

        Instantiate(_platformPref, randomSpawnPoint.position, Quaternion.identity);
    }
}
