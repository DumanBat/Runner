using Eventyr.EndlessRunner.Scripts.Data;
using Eventyr.EndlessRunner.Scripts.Interfaces;
using Eventyr.EndlessRunner.Scripts.ScriptableObjects;
using Eventyr.EndlessRunner.Scripts.Utils;
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
            BindGameConfig();
            BindUserData();
            BindDataController();
        }

        private void BindGameConfig()
        {
            Container.Bind<GameConfig>()
                .FromScriptableObject(_config)
                .AsSingle();
        }

        private void BindUserData()
        {
            Container.Bind<IUserData>()
                .To<UserData>()
                .FromInstance(new UserData())
                .AsSingle();
        }

        private void BindDataController()
        {
            Container.Bind<IUserDataControllerService>()
                .To<UserDataController>()
                .AsSingle();
        }
    }
}