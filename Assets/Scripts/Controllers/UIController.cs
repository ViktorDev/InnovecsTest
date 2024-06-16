using TMPro;
using UniRx;
using UnityEngine;

namespace InnovecsTest
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _scoreLabel;
        private int score;

        private void Start()
        {
            MessageBroker.Default.Receive<AnimalReachedYardMessage>()
            .Subscribe(_ => IncreaseScore())
            .AddTo(this);

            score = 0;
            UpdateScoreText();
        }

        public void IncreaseScore()
        {
            score++;
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            _scoreLabel.text = "Score: " + score;
        }
    }
}
