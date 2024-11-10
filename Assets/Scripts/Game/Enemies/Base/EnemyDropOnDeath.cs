using UnityEngine;

namespace TDS.Game.Enemies.Base
{
    [RequireComponent(typeof(EnemyDeath))]
    public class EnemyDropOnDeath : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _dropItemPrefab;

        private EnemyDeath _death;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _death = GetComponent<EnemyDeath>();
        }

        private void OnEnable()
        {
            _death.OnDeath += DropItem;
        }

        private void OnDisable()
        {
            _death.OnDeath -= DropItem;
        }

        #endregion

        #region Private methods

        private void DropItem()
        {
            Instantiate(_dropItemPrefab, transform.position, Quaternion.identity);
        }

        #endregion
    }
}