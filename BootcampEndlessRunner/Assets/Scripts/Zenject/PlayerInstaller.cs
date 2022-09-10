using Eventyr.EndlessRunner.Scripts.Behaviours;
using Eventyr.EndlessRunner.Scripts.Interfaces;
using Eventyr.EndlessRunner.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.Zenject
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField]
        private PlayerController _playerControllerPrefab;

        public override void InstallBindings()
        {
            Container.BindFactory<PlayerController, PlayerController.Factory>().FromComponentInNewPrefab(_playerControllerPrefab);

            Container.Bind<ISideSwitch>().To<SwitchSideBehaviour>().AsSingle();
        }
    }
}