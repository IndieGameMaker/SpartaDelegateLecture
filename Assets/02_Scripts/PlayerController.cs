using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 델리게이트 (Delegate : 대리자)
 int a = 1;
 float b = 2.0f;
 
 function c = function_C; (?)
 
 델리게이트 변수명 = 메소드(함수)
 
 */

interface IDamageable
{
    void TakeDamage(int damage);
}

public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] private int hp = 100;
    
    // 델리게이트 선언
    public delegate void PlayerHpHandler(int currHp, int maxHp);
    
    // 델리게이트 변수 선언
    public static PlayerHpHandler OnPlayerHpChanged;
    
    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log($"피격 {hp}");

        OnPlayerHpChanged?.Invoke(hp, 100);
        
        if (hp <= 0)
        {
            Debug.Log("플레이어 사망");
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 300, 100), "Take Damage"))
        {
            TakeDamage(20);
        }
    }
}
