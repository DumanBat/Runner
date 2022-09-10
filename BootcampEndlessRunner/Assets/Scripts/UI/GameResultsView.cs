using Eventyr.EndlessRunner.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Eventyr.EndlessRunner.Scripts.UI
{
    public class GameResultsView : MonoBehaviour, IGameResults
    {
        [SerializeField]
        private Transform _root;
        [SerializeField]
        private TextMeshProUGUI _scoreDisplay;
        [SerializeField]
        public Button _playAgainButton;

        public TextMeshProUGUI ScoreDisplay => _scoreDisplay;
        public Button PlayAgainButton => _playAgainButton;

        public void ShowResults(int scoreAmount)
        {
            _root.gameObject.SetActive(true);
            _scoreDisplay.text = scoreAmount.ToString();
        }

        public void SetActivePanel(bool isActive) => _root.gameObject.SetActive(isActive);
    }
}
