using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// 徐々に上昇していくスコアゲージ
/// </summary>
public class ScoreGauge : MonoBehaviour
{
    /// <summary>
    /// ゲージの最大値をこれとする
    /// </summary>
    const float MaxValue = 100;

    /// <summary>
    /// ゲージ本体
    /// </summary>
    [SerializeField]
    Image gauge;

    /// <summary>
    /// ゲージ上昇速度(一秒でどれぐらい上がるか)
    /// </summary>
    [SerializeField]
    float scoreUpRate;


    /// <summary>
    /// ゲージが満タンになったときの処理
    /// </summary>
    [SerializeField]
    UnityEvent OnScoreUp;

    /// <summary>
    /// 効果音
    /// </summary>
    [SerializeField]
    AudioSource gaugeSound;

    /// <summary>
    /// ゲージが空の時の効果音のピッチ
    /// </summary>
    [SerializeField]
    float soundPitchStart;

    /// <summary>
    /// ゲージが満タンの時の効果音のピッチ
    /// </summary>
    [SerializeField]
    float soundPitchEnd;

    /// <summary>
    /// 現在のゲージの量
    /// </summary>
    float value = 0;

    bool isScoreUp = false;

    private void Awake()
    {
        gauge.fillAmount = 0;
    }

    private void Update()
    {
        if (isScoreUp)
        {
            GaugeUp();
        }

        GaugeCheck();

        Draw();
    }

    /// <summary>
    /// ゲージ上昇
    /// </summary>
    private void GaugeUp()
    {
        value += scoreUpRate * Time.deltaTime;
    }

    private void GaugeCheck()
    {
        if (value >= MaxValue)
        {
            OnScoreUp.Invoke();
            value = 0;
        }
    }

    /// <summary>
    /// ゲージに反映
    /// </summary>
    private void Draw() 
    {
        gauge.fillAmount = value / MaxValue;
        float pitch;
        pitch = soundPitchStart + (soundPitchEnd - soundPitchStart) * (value / MaxValue);
        gaugeSound.pitch = pitch;
    }

    /// <summary>
    /// スコア上昇を開始させる
    /// </summary>
    public void Up()
    {
        isScoreUp = true;
        if (!gaugeSound.isPlaying)
        {
            gaugeSound.Play();
        }
    }

    /// <summary>
    /// スコア上昇を停止させる
    /// </summary>
    public void Stop()
    {
        isScoreUp = false;
        if (gaugeSound.isPlaying)
        {
            gaugeSound.Pause();
        }
    }
}
