using CodeBase.Enemy;
using UnityEngine;

namespace CodeBase.Spawner
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Slime _slime;
        [SerializeField] private float _duration = 2f;
        
        private SpawnPoint[] _points;
        private int _currentPoint = 0;
        private float _time = 0;

        private void Start()
        {
            _points = GetComponentsInChildren<SpawnPoint>();
        }

        private void Update()
        {
            if (_time >= _duration)
            {
                if (_currentPoint >= _points.Length)
                    _currentPoint = 0;

                CreateEnemyInstance(_slime, _points[_currentPoint].transform.position);
                _currentPoint++;
                _time = 0;
            }
            else
            {
                _time += Time.deltaTime;
            }
        }

        private void CreateEnemyInstance(Slime enemy, Vector3 positionSpawner)
        {
            Instantiate(enemy, positionSpawner, Quaternion.identity);
        }
    }
}