using TDS.Architecture.Services;
using UnityEngine;

namespace TDS.Architecture.States
{
    public class BootstrapState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            Debug.Log($"'{nameof(BootstrapState)}' was entered.");
            ServiceLocator.Instance.Register(new SceneLoaderService());
            StateMachine.Enter<LoadGameState>();
        }

        public override void Exit() { }

        #endregion
    }
}