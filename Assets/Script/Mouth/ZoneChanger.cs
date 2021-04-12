using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// スライダーの各ゾーンの値を管理
/// </summary>
public class ZoneChanger : MonoBehaviour
{
    /// <summary>
    /// ゾーンの最大値
    /// </summary>
    const float MaxValue = 100;

    /// <summary>
    /// ゲームオーバーゾーンのゲージ
    /// </summary>
    [SerializeField]
    Image deadZone;
    [SerializeField]
    float deadZoneStartSize;

    /// <summary>
    /// 安全ゾーンのゲージ
    /// </summary>
    [SerializeField]
    Image safeZone;
    [SerializeField]
    float safeZoneStartSize;

    [SerializeField]
    Slider Mouth;

    /// <summary>
    /// ゲームオーバーになるゾーンの位置
    /// </summary>
    float deadZoneSize;
    /// <summary>
    /// 安全ゾーンとスコアゾーンの間の位置
    /// </summary>
    float safeZoneSize;

    private void Awake()
    {
        deadZoneSize = deadZoneStartSize;
        safeZoneSize = safeZoneStartSize;
        Draw();
    }

    /// <summary>
    /// 状態を画面に反映する
    /// </summary>
    private void Draw()
    {
        //safeZoneの反映
        safeZone.fillAmount = safeZoneSize / MaxValue;
        //deadZoneの反映
        deadZone.fillAmount = 1.0f - deadZoneSize / MaxValue;
    }

}
