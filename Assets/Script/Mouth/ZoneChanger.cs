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
    float deadZoneBaseSize;
    [SerializeField]
    float deadZoneNoiseSize;

    /// <summary>
    /// 安全ゾーンのゲージ
    /// </summary>
    [SerializeField]
    Image safeZone;
    [SerializeField]
    float safeZoneBaseSize;
    [SerializeField]
    float safeZoneNoiseSize;


    [SerializeField]
    float noiseSpeed;

    [SerializeField]
    float moneyZoneMinSize;
        
    /// <summary>
    /// ゲームオーバーになるゾーンの位置
    /// </summary>
    float deadZoneSize;
    float deadZoneNoiseX;
    float deadZoneBase = 0;

    /// <summary>
    /// 安全ゾーンとスコアゾーンの間の位置
    /// </summary>
    float safeZoneSize;
    float safeZoneNoiseY;
    float safeZoneBase = 0;

    float noiser;

    private void Awake()
    {
        deadZoneSize = 0;
        safeZoneSize = 0;
        deadZoneNoiseX = Random.Range(0f, 100f);
        safeZoneNoiseY = Random.Range(0f, 100f);



        Draw();
    }


    private void Update()
    {
        //ゲージの変形
        ChangeGauge();

        //画面に反映
        Draw();
    }


    private void ChangeGauge()
    {
        //noiseSpeed += Time.deltaTime * 0.05f;
        noiser += Time.deltaTime * noiseSpeed;
        deadZoneBase = MathKoji.GetCloser(deadZoneBase, deadZoneBaseSize, 5);
        safeZoneBase = MathKoji.GetCloser(safeZoneBase, safeZoneBaseSize, 5);


        deadZoneSize = MaxValue - (deadZoneBase + Mathf.PerlinNoise(deadZoneNoiseX, noiser) * deadZoneNoiseSize);
        safeZoneSize = safeZoneBase + Mathf.PerlinNoise(noiser, safeZoneNoiseY) * safeZoneNoiseSize;

        if (deadZoneSize - safeZoneSize < moneyZoneMinSize)
        {
            safeZoneSize = deadZoneSize - moneyZoneMinSize;
        }
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

    public float GetDeadZoneSize()
    {
        return deadZoneSize;
    }

    public float GetSafeZoneSize()
    {
        return safeZoneSize;
    }
}
