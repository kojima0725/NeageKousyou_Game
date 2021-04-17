﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    string changeTo;
    public void Change()
    {
        SceneManager.LoadScene(changeTo);
    }
}
