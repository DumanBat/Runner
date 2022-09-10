using Eventyr.EndlessRunner.Scripts.MainMenu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.Zenject
{
    public class MenuSceneInstaller : MonoInstaller
    {
        [SerializeField]
        private MainMenuView _mainMenuViewPrefab;

        public override void InstallBindings()
        {
            BindMainMenuView();
        }

        private void BindMainMenuView()
        {
            var mainMenuView = Container.InstantiatePrefabForComponent<MainMenuView>(_mainMenuViewPrefab);

            Container.Bind<IMainMenuView>()
                .FromInstance(mainMenuView)
                .AsSingle();
        }
    }
}
