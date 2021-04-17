using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 計算機
/// </summary>
public class MathKoji : MonoBehaviour
{
    /// <summary>
    /// ある値をある値に近づける
    /// </summary>
    /// <param name="current">現在</param>
    /// <param name="to">目標</param>
    /// <param name="rate">どれぐらい近づけるか</param>
    /// <returns>近づけた結果</returns>
    public static float GetCloser(float current, float to, float rate, bool time = true)
    {
        if (time)
        {
            rate *= Time.deltaTime;
        }
        if (current < to)
        {
            current += rate;
            if (current > to)
            {
                return to;
            }
            else
            {
                return current;
            }
        }
        else if (current > to)
        {
            current -= rate;
            if (current < to)
            {
                return to;
            }
            else
            {
                return current;
            }
        }
        else
        {
            return current;
        }
    }

    /// <summary>
    /// 子のすべてのレイヤーを変える
    /// </summary>
    /// <param name="obj">変えるオブジェ</param>
    public static void SetLayer(GameObject obj, int setLayer)
    {
        obj.layer = setLayer;
        foreach (Transform transform in obj.transform)
        {
            SetLayer(transform.gameObject, setLayer);
        }
    }


    
}
