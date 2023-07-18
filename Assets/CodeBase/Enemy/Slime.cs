using UnityEngine;

namespace CodeBase.Enemy
{
   public class Slime : MonoBehaviour
   {
      [SerializeField] private SpriteRenderer _targetRenderer;
      [SerializeField] private float _duration;

      private float _runningTime;
      private float _normalizeTime;
      
      private void Update()
      {
         if (_runningTime <= _duration)
         {
            _runningTime += Time.deltaTime;
            _normalizeTime = _runningTime / _duration;
            _targetRenderer.color = Color.Lerp(_targetRenderer.color, Color.red, _normalizeTime);
         }
         else if (_normalizeTime >= _duration)
         {
            Destroy(gameObject);
         }
      }
   }
}
