using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void OnEnable()
    {
        PlayerController.OnPlayerHpChanged += UpdateHpBar;
        PlayerController.OnGainPlayerExp += UpdatePlayerExp;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerHpChanged -= UpdateHpBar;
        PlayerController.OnGainPlayerExp -= UpdatePlayerExp;
    }

    private void UpdatePlayerExp(int exp)
    {
        // 경험치 UI 갱신
        Debug.Log($"플레이어 경험치 +{exp}");
    }

    private void UpdateHpBar(int currHp, int maxHp)
    {
        Debug.Log($"피격 {currHp}/{maxHp}");
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(3.0f);
        PlayerController.OnPlayerHpChanged?.Invoke(10,100);
    }
}
