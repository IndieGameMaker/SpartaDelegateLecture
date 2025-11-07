using System;
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
    
    // 1. 델리게이트 문법
    // // 델리게이트 선언
    // public delegate void PlayerHpHandler(int currHp, int maxHp);
    //
    // // 델리게이트 변수 선언
    // public static PlayerHpHandler OnPlayerHpChanged;
    
    // 2. Action
    // 반환값이 없는 델리게이트
    // .NET에 미리 정의되어 있는 내장 델리게이트
    public static Action<int, int> OnPlayerHpChanged;

    public static Action OnPlayerDie;
    
    // 3. Func
    // 반환값이 있는 델리게이트 
    // Func<T1, T2, ...., Tn>
    public static Func<int, int, int> OnHealing = (currHp, healAmount) => currHp + healAmount;
    
    // 4. Event
    // 외부 클래스에서 +=, -= 허용, 직접 Invoke 할 수 없다.
    // 캡슐화(보안성)

    public static event Action<int> OnGainPlayerExp;

    // 플레이어 경험치
    private int playerExp = 0;
    
    public void GainPlayerExp(int exp)
    {
        playerExp += exp;
        OnGainPlayerExp?.Invoke(playerExp);
    }
    
    public void Heal(int amount)
    {
        hp = OnHealing(hp, amount);
        Debug.Log("Heal " + hp);
    }
    
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
        
        if (GUI.Button(new Rect(10, 110, 300, 100), "Heal"))
        {
            Heal(10);
        }
        
        if (GUI.Button(new Rect(10, 210, 300, 100), "Take Exp"))
        {
            GainPlayerExp(1000);
        }
    }
}
