using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// ステージの管理をする（ゲームオーバーなど）
/// </summary>
public class StageManager : MonoBehaviour
{
    /// <summary>
    /// 口の位置を把握するため
    /// </summary>
    [SerializeField]
    MouthSlider mouth;

    /// <summary>
    /// メインゲージを把握するため
    /// </summary>
    [SerializeField]
    ZoneChanger zone;

    /// <summary>
    /// ゲームオーバー時に発生するイベント
    /// </summary>
    [SerializeField]
    UnityEvent OnGameOver;
    /// <summary>
    /// スコア上昇時に発生するイベント
    /// </summary>
    [SerializeField]
    UnityEvent OnScoreUp;
    /// <summary>
    /// それ以外のときに発生するイベント
    /// </summary>
    [SerializeField]
    UnityEvent OnNotScoreUp;


    bool isGameing = true;


    private void Update()
    {
        if (isGameing)
        {
            GameCheck();
        }
    }

    /// <summary>
    /// ゲームの進行を確認する
    /// </summary>
    private void GameCheck()
    {
        float mouthSize = mouth.GetMouthSize();
        float deadZone = zone.GetDeadZoneSize();
        float safeZone = zone.GetSafeZoneSize();

        if (mouthSize > deadZone)
        {
            OnGameOver.Invoke();
            OnNotScoreUp.Invoke();
            GameOver();
        }
        else if (mouthSize >= safeZone)
        {
            OnScoreUp.Invoke();
        }
        else
        {
            OnNotScoreUp.Invoke();
        }
    }

    private void GameOver()
    {
        isGameing = false;
        Debug.Log("ゲームオーバー");
    }
}
