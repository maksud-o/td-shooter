using System;
using TDS.Architecture;
using TDS.Architecture.Services;
using UnityEngine;

namespace TDS.Game
{
    public class LevelCompletionHandler : MonoBehaviour
    {
        [SerializeField] private string _nextLevelName;
        [SerializeField] private TriggerObserver _nextLevelTrigger;

        private void OnEnable()
        {
            _nextLevelTrigger.OnEnter += TriggerEnter2DCallback;
        }

        private void OnDisable()
        {
            _nextLevelTrigger.OnEnter -= TriggerEnter2DCallback;
        }
        
        private void TriggerEnter2DCallback(Collider2D collision)
        {
            var loader = ServiceLocator.Instance.Get<SceneLoaderService>();
            loader.Load(_nextLevelName);
        }
    }
}