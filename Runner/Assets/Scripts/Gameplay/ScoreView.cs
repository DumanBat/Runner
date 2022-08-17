using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Eventyr.EndlessRunner.Scripts.Interfaces;

namespace Eventyr.EndlessRunner.Scripts.Gameplay
{
    public class ScoreView : MonoBehaviour, IScoringServiceView
    {
        [SerializeField]
        private TextMeshProUGUI _scoreDisplay;

        TextMeshProUGUI IScoringServiceView.ScoreDisplay => _scoreDisplay;
    }
}