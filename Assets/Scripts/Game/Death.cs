using UnityEngine;

namespace TDS.Game
{
    public abstract class Death : MonoBehaviour
    {
        #region Protected methods

        protected abstract void Die();

        #endregion
    }
}