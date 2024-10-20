using TDS.Architecture;
using TDS.Architecture.States;
using UnityEngine;

namespace TDS
{
    public class Bootstrap : MonoBehaviour
    {
        #region Unity lifecycle

        private void Awake()
        {
            StateMachine sm = new();
            ServiceLocator.Instance.Register(sm);
            sm.Enter<BootstrapState>();
        }

        #endregion
    }
}