using Eventyr.EndlessRunner.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.Zenject
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField]
        private GameConfig _config;

        public override void InstallBindings()
        {
            Container.Bind<GameConfig>().FromScriptableObject(_config).AsSingle();
        }
    }
}