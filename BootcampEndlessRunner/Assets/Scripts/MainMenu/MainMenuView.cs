using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Eventyr.EndlessRunner.Scripts.MainMenu
{
    public class MainMenuView : MonoBehaviour, IMainMenuView
    {
        [Header("Main Menu Panel")]
        [SerializeField]
        private TextMeshProUGUI _nameDisplay;
        [SerializeField]
        private TextMeshProUGUI _maxScoreDisplay;
        [SerializeField]
        private Button _startGameButton;
        [SerializeField]
        private Button _changeNameButton;

        [Header("Name Change Panel")]
        [SerializeField]
        private Transform _nameChangeRoot;
        [SerializeField]
        private TMP_InputField _nameInput;
        [SerializeField]
        private Button _submitNameChangeButton;

        public TextMeshProUGUI UserName => _nameDisplay;
        public TextMeshProUGUI MaxScore => _maxScoreDisplay;
        public Button StartGameButton => _startGameButton;
        public Button ChangeNameButton => _changeNameButton;

        public Transform NameChangeRoot => _nameChangeRoot;
        public TMP_InputField NameInput => _nameInput;
        public Button SubmitNameChangeButton => _submitNameChangeButton;

        public void EnableNameChangePanel() => _nameChangeRoot.gameObject.SetActive(true);
    }
}
