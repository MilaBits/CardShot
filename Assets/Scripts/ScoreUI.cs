using System;
using System.Collections;
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

    private float p1Health = 100;
    private float p2Health = 100;

    private int roundTime;

    [SerializeField, BoxGroup("Round")]
    private TextMeshProUGUI roundTimeText;

    public void SetRoundTime(int time) {
        roundTimeText.text = $"{Math.Floor(time / 60f)}:{time % 60}";
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

    public void ResetRoundState() {
        p1Health = 100;
        p2Health = 100;
        StartCoroutine(LerpRoundState(.5f, 1f));
    }

    public void SetRoundState(Team team, float health) {
        switch (team) {
            case Team.Blue:
                p1Health = health;
                break;
            case Team.Red:
                p2Health = health;
                break;
        }

        float redPercent = p2Health / (p1Health + p2Health);

        StartCoroutine(LerpRoundState(redPercent, .5f));
    }

    private IEnumerator LerpRoundState(float newValue, float time) {
        float elapsedTime = 0;
        float startingValue = RoundState.fillAmount;
        while (elapsedTime < time) {
            RoundState.fillAmount = Mathf.Lerp(RoundState.fillAmount, newValue, time);

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}