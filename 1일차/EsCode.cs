using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsCode : MonoBehaviour
{
    public int Level = 10;
    public float Hp = 100.0f;
    public bool IsDead = false;
    public string Playername = "이름";

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++) {
            Debug.Log(i + "번째 반복입니다");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("이름 : " +  Playername + "레벨 :" + Level + "HP :" + Hp);
            Attack(5);
        }

        if (Hp > 0)
        {
            Debug.Log("현재 체력 : " + Hp);
        }
        else
        {
            Debug.Log("죽었습니다,");
            IsDead = true;
        }
    }

    void Attack(float Damage) { //데미지 함수 선언 (메개변수)
        
        //Hp = Hp - Damage;

        Hp -= Damage;
    }
}