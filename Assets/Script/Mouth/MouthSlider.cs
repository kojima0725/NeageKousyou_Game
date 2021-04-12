using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 上下する口のスライダー
/// </summary>
[RequireComponent(typeof(Slider))]
public class MouthSlider : MonoBehaviour
{
    /// <summary>
    /// スライダーの値の範囲を0～これとして計算を行う
    /// </summary>
    const float MaxValue = 100;

    /// <summary>
    /// スライダーコンポーネント
    /// </summary>
    Slider slider;

    /// <summary>
    /// 重力加速度
    /// </summary>
    [SerializeField]
    float gravity;

    /// <summary>
    /// ジャンプする強さ
    /// </summary>
    [SerializeField]
    float jumpPower;

    /// <summary>
    /// 現在の速さ
    /// </summary>
    private float speed = 0;

    /// <summary>
    /// 現在の位置
    /// </summary>
    private float pos;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        pos = slider.value * MaxValue;
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        //重力を加える
        AddG();
        Move();
        //画面に反映
        Draw();
    }

    /// <summary>
    /// スライダーを飛び上がらせる
    /// </summary>
    public void Jump()
    {
        speed = jumpPower;
    }



    /// <summary>
    /// 重力を加える
    /// </summary>
    private void AddG()
    {
        speed -= gravity * Time.deltaTime;
    }

    private void Move()
    {
        pos += speed * Time.deltaTime;
        if (pos < 0)
        {
            pos = 0;
            speed = 0;
        }
        else if (pos > MaxValue)
        {
            pos = MaxValue;
        }
    }

    /// <summary>
    /// 値を画面上のスライダーに反映する
    /// </summary>
    private void Draw()
    {
        slider.value = pos / MaxValue;
    }
}
