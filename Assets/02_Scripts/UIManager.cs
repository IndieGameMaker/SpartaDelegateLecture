using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerController.OnPlayerHpChanged += UpdateHpBar;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerHpChanged -= UpdateHpBar;
    }

    private void UpdateHpBar(int currHp, int maxHp)
    {
        Debug.Log($"피격 {currHp}/{maxHp}");
    }
}
