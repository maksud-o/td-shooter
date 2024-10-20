using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace TDS.Architecture
{
    public class ServiceLocator : MonoBehaviour
    {
        #region Variables

        private static ServiceLocator _instance;

        private readonly Dictionary<Type, IService> _services = new();

        #endregion

        #region Properties

        public static ServiceLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new(nameof(ServiceLocator));
                    DontDestroyOnLoad(go);
                    _instance = go.AddComponent<ServiceLocator>();
                }

                return _instance;
            }
        }

        #endregion

        #region Public methods

        public T Get<T>() where T : class, IService
        {
            Assert.IsTrue(_services.ContainsKey(typeof(T)), $"Service '{typeof(T).Name}' not registered.");
            return _services[typeof(T)] as T;
        }

        public void Register<T>(T service) where T : class, IService
        {
            Assert.IsFalse(_services.ContainsKey(typeof(T)),
                $"Service '{typeof(T).Name}' already registered.");

            _services.Add(typeof(T), service);
        }

        public T RegisterMono<T>() where T : IService
        {
            throw new NotImplementedException();
        }

        public void UnRegister<T>() where T : class, IService
        {
            _services.Remove(typeof(T));
        }

        #endregion
    }
}