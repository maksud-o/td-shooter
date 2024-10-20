using TDS.Architecture.Services;
using UnityEngine;

namespace TDS.Architecture.States
{
    public class LoadGameState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            Debug.Log($"'{nameof(LoadGameState)}' was entered.'");

            var loader = ServiceLocator.Instance.Get<SceneLoaderService>();
            loader.Load(SceneNames.GAME);

            StateMachine.Enter<GameState>();
        }

        public override void Exit() { }

        #endregion
    }
}