using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


/// <summary>
/// 画面上に表示されるタイマーで、タイムアップでゲームが終了する
/// </summary>
public class Timer : MonoBehaviour
{
    /// <summary>
    /// タイマーの設定時間
    /// </summary>
    [SerializeField]
    float resetTime;

    /// <summary>
    /// タイムアップ時に発生するイベント
    /// </summary>
    [SerializeField]
    UnityEvent OnTimeUp;

    /// <summary>
    /// 画面上に表示されるテキスト
    /// </summary>
    [SerializeField]
    Text text;

    /// <summary>
    /// 現在の時間
    /// </summary>
    float time;

    /// <summary>
    /// タイマーを作動させるかどうか
    /// </summary>
    bool active = true;

    private void Awake()
    {
        time = resetTime;
    }

    private void Update()
    {
        if (active)
        {
            time -= Time.deltaTime;
            if (time < 4)
            {
                text.color = Color.red;
            }
            else
            {
                text.color = Color.white;
            }

            if (time < 1)
            {
                TimeUp();
            }


            text.text = "残り時間:" + (int)time　+ "秒";
        }
    }

    /// <summary>
    /// タイムアップ時の処理
    /// </summary>
    private void TimeUp()
    {
        OnTimeUp.Invoke();
        active = false;
        text.text = "残り時間:0秒";
    }

    /// <summary>
    /// タイマーをリセットする
    /// </summary>
    public void ResetTime()
    {
        time = resetTime;
    }

    /// <summary>
    /// タイマーを停止する
    /// </summary>
    public void Stop()
    {
        active = false;
    }
}
