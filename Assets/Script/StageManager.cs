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
    UnityEvent OnGameEnd;
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
    /// <summary>
    /// 料金の表示されるテキスト
    /// </summary>
    [SerializeField]
    Text moneyText;
    [SerializeField]
    int startMoney;

    /// <summary>
    /// 現在の買取価格
    /// </summary>
    int money;


    bool isGameing = true;

    private void Awake()
    {
        money = startMoney;
        Draw();
    }

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

    /// <summary>
    /// 画面上に状況を適用
    /// </summary>
    private void Draw()
    {
        moneyText.text = "買取価格:" + money + "万円";
    }

    private void GameOver()
    {
        isGameing = false;
        Debug.Log("ゲームオーバー");
        OnGameEnd.Invoke();
    }

    public void TimeUped()
    {
        isGameing = false;
        Debug.Log("タイムアップ");
        OnGameEnd.Invoke();
    }

    /// <summary>
    /// 買取価格の上昇
    /// </summary>
    public void MoneyUp()
    {
        money++;
        Draw();
    }
}
