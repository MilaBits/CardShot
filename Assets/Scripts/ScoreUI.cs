using System;
using DefaultNamespace;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {
    [HorizontalGroup("Match")]
    [SerializeField, BoxGroup("Match/Blue")]
    [LabelText("Score"), LabelWidth(50), Range(0, 3)]
    private int BlueScore;

    [SerializeField, BoxGroup("Match/Blue")]
    [LabelText("Image"), LabelWidth(50)]
    private Image BlueScoreImage;

    [SerializeField, BoxGroup("Match/Red")]
    [LabelText("Score"), LabelWidth(50), Range(0, 3)]
    private int RedScore;

    [SerializeField, BoxGroup("Match/Red")]
    [LabelText("Image"), LabelWidth(50)]
    private Image RedScoreImage;

    [SerializeField, BoxGroup("Round")]
    private Image RoundState;

    private int roundTime;

    [SerializeField, BoxGroup("Round")]
    private TextMeshProUGUI roundTimeText;

    public void SetRoundTime(int time) {
        roundTimeText.text = $"{Math.Floor(time / 60f)}:{time % 60}";
    }

    private void UpdateRoundState() {
    }

    [Button]
    private void Reset() {
        BlueScore = 0;
        RedScore = 0;
        UpdateUI();
    }

    [Button("Add Score"), BoxGroup("Match/Blue")]
    private void AddBlueScore() {
        BlueScore++;
        UpdateUI();
    }

    [Button("Add Score"), BoxGroup("Match/Red")]
    private void AddRedScore() {
        RedScore++;
        UpdateUI();
    }

    [Button]
    private void UpdateUI() {
        BlueScoreImage.fillAmount = .33f * BlueScore;
        RedScoreImage.fillAmount = .33f * RedScore;
    }

    public void AddScore(Team team) {
        switch (team) {
            case Team.Blue:
                BlueScore++;
                break;
            case Team.Red:
                RedScore++;
                break;
        }

        UpdateUI();

        if (BlueScore >= 3) {
            // blue wins
        }

        if (RedScore >= 3) {
            // red wins
        }
    }
}