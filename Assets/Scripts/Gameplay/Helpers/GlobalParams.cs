using System;
using Gameplay.ShipControllers.CustomControllers;
using UnityEngine;

namespace Gameplay.Helpers
{
    public class GlobalParams : MonoBehaviour
    {
        public static GlobalParams Instance;

        private int _score = 0;

        [SerializeField] private ProgressBar _hpBar;
        [SerializeField] private TMPro.TextMeshProUGUI _textScore;
        [SerializeField] private TMPro.TextMeshProUGUI _textScoreGameOver;
        [SerializeField] private GameObject _iconBoost;
        public void Awake()
        {
            Instance = this;
            _score = 0;
            UpdateScore();
        }

        public void ApplyScore(int score)
        {
            _score += score;
            UpdateScore();
        }

        private void UpdateScore()
        {
            _textScore.text = _score.ToString();
        }

        public void UpdateBarHP(int hp, int maxHp)
        {
            _hpBar.SetValueMax(maxHp);
            _hpBar.SetValue(hp);
        }

        public void OnDiePlayer()
        {
            Debug.Log("Игрок сдох");
            _textScoreGameOver.text = "Набрано очков: \n" + _score.ToString();
            GameOver.Instance.StartAnimGameOver();
        }

        public void SetBoostStatus(bool status)
        {
            _iconBoost.SetActive(status);
        }
    }
}