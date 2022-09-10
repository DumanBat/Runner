using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Eventyr.EndlessRunner.Scripts.Interfaces
{
    public interface IGameResults
    {
        public TextMeshProUGUI ScoreDisplay { get; }

        public Button PlayAgainButton { get; }

        public void ShowResults(int scoreAmount);

        public void SetActivePanel(bool isActive);
    }
}
