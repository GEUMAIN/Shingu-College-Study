using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsCode : MonoBehaviour
{
    public int Level = 10;
    public float Hp = 100.0f;
    public bool IsDead = false;
    public string Playername = "�̸�";

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++) {
            Debug.Log(i + "��° �ݺ��Դϴ�");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("�̸� : " +  Playername + "���� :" + Level + "HP :" + Hp);
            Attack(5);
        }

        if (Hp > 0)
        {
            Debug.Log("���� ü�� : " + Hp);
        }
        else
        {
            Debug.Log("�׾����ϴ�,");
            IsDead = true;
        }
    }

    void Attack(float Damage) { //������ �Լ� ���� (�ް�����)
        
        //Hp = Hp - Damage;

        Hp -= Damage;
    }
}