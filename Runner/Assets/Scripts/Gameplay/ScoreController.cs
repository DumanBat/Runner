using Eventyr.EndlessRunner.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Eventyr.EndlessRunner.Scripts.Gameplay
{
    public class ScoreController : IScoringService
    {
        private int _scoredCoins;
        private IScoringServiceView _scoreView;

        public int Score => _scoredCoins;

        public ScoreController(IScoringServiceView scoreView)
        {
            _scoreView = scoreView;
        }

        public void Init()
        {
            _scoredCoins = 0;
            _scoreView.ScoreDisplay.text = _scoredCoins.ToString();
        }

        public void AddScore()
        {
            _scoredCoins += 1;
            _scoreView.ScoreDisplay.text = _scoredCoins.ToString();
        }
    }
}
