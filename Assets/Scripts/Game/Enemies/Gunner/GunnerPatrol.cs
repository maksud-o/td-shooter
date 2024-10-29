using System.Collections;
using System.Linq;
using TDS.Game.Enemies.Base;
using UnityEngine;

namespace TDS.Game.Enemies.Gunner
{
    [RequireComponent(typeof(EnemyMovement))]
    public class GunnerPatrol : EnemyPatrol
    {
        #region Variables

        [SerializeField] private float _pauseBetweenPoints = 3f;

        private EnemyMovement _movement;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _movement = GetComponent<EnemyMovement>();
            
            _movement.Activate();
        }

        private void OnEnable()
        {
            StartCoroutine(Patrol());
        }

        private void OnDisable()
        {
            StopCoroutine(Patrol());
        }

        #endregion

        #region Private methods

        private IEnumerator Patrol()
        {
            Transform[] patrolPoints = PatrolPoints.ToArray();
            while (true)
            {
                if (patrolPoints.Length <= 1)
                {
                    break;
                }

                foreach (Transform point in PatrolPoints)
                {
                    _movement.SetTarget(point);
                    yield return new WaitUntil(() => transform.position == point.position);
                    yield return new WaitForSeconds(_pauseBetweenPoints);
                }

                patrolPoints = patrolPoints.Reverse().ToArray();
            }
        }

        #endregion
    }
}