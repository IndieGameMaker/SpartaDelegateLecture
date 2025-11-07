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

public class PlayerController : MonoBehaviour
{
    // 1. 델리게이트를 선언
    private delegate void SampleDelegate();
    
    void Start()
    {
        // 델리게이트 변수에 메소드를 할당
        SampleDelegate sample = Sample01;
        
        // 델리게이트 실행
        sample?.Invoke();
    }

    private void Sample01()
    {
        Debug.Log("Sample01 호출");
    }
}
