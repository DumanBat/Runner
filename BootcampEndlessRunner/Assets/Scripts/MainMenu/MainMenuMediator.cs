using Eventyr.EndlessRunner.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.MainMenu
{
    public class MainMenuMediator : MonoBehaviour
    {
        private IUserDataControllerService _dataControllerService;
        private IMainMenuView _mainMenuView;

        [Inject]
        public void Construct(IUserDataControllerService dataControllerService, IMainMenuView mainMenuView)
        {
            _dataControllerService = dataControllerService;
            _mainMenuView = mainMenuView;
        }

        private void Awake()
        {
            _mainMenuView.ChangeNameButton.onClick.AddListener(_mainMenuView.EnableNameChangePanel);
            _mainMenuView.SubmitNameChangeButton.onClick.AddListener(SubmitNameChange);
            _mainMenuView.StartGameButton.onClick.AddListener(LoadGameScene);

            Init();
        }

        public void Init()
        {
            SetUserInfo();
        }

        private void SetUserInfo()
        {
            if (!_dataControllerService.LoadUserData())
            {
                _mainMenuView.UserName.text = "";
            }
            else
            {
                _mainMenuView.UserName.text = _dataControllerService.UserData.UserName;
                _mainMenuView.MaxScore.text = _dataControllerService.UserData.MaxScore.ToString();
            }
        }

        private void SubmitNameChange()
        {
            var newName = _mainMenuView.NameInput.text;
            _dataControllerService.SetUserData(newName, "", 0);
            _dataControllerService.WriteUserDataToJsonLocal();
            SetUserInfo();
            _mainMenuView.NameChangeRoot.gameObject.SetActive(false);
        }

        private void LoadGameScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}
