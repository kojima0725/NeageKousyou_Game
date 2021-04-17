using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 画像切り替え機
/// </summary>
public class ImageChanger : MonoBehaviour
{
    Image image;

    [SerializeField]
    Sprite[] sprites;

    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
    }

    public void ChangeImage()
    {
        image.sprite = sprites[Random.Range(0, sprites.Length)];
    }
}
