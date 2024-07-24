using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float Speed = 5.0f;
    public int VerticalDirection = 1;
    public int HorizontalDirection = 1;
    public Rigidbody2D Rigidbody;
    


    void Start()
    {
        int randomNumber = Random.Range(0, 2); // 0 ~ 1 ������ ���� ���� ����   

        if (randomNumber == 0)
        { //���� ���ڰ� 0�϶�

            HorizontalDirection = 1; //���� ������ ���������� ��ȭ
        }
        else //���� ���ڰ� 1�� �ƴҶ�
        {
            HorizontalDirection = 0; //���� ������ �������� ����
        }

        VerticalDirection = 1; //���� ���� ������ �Ʒ��� ����

        Rigidbody.velocity = new Vector2(Speed * HorizontalDirection, Speed * VerticalDirection);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall") { //���� �浹�� ��ü�� tag�� Wall �̶��

            VerticalDirection *= -1; //���� ���� ����

        }

        if (collision.transform.tag == "Player") { //�浹�� ��ü�� tag�� Player���
            HorizontalDirection *= -1; //�¿� ���� ����
        }

        //���� �ӵ��� ����
        Rigidbody.velocity = new Vector2(Speed * HorizontalDirection, Speed * VerticalDirection);
    }
}
