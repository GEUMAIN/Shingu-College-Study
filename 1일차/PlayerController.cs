using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5.0f; //�÷��̾� �ӵ�

    
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)) //���� ȭ��ǥ�� ������ ������
        {
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow)) //���� ȭ��ǥ�� ������ ������
        {
            transform.Translate(Vector2.down * Speed * Time.deltaTime);
        }

        if (transform.position.y > 3)
        { //������Ʈ�� y ��ǥ�� �ִ� ���� 3���� Ŭ ��
            transform.position = new Vector2(transform.position.x, 3); // y��ǥ�� �ִ���̷� �̵�
        }

        if (transform.position.y < -3)
        { //������Ʈ�� y ��ǥ�� �ִ� ���� -3���� ���� ��
            transform.position = new Vector2(transform.position.x, -3); // y��ǥ�� �������̷� �̵�
        }
    }
}
