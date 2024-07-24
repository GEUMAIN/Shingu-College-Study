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
        int randomNumber = Random.Range(0, 2); // 0 ~ 1 까지의 랜덤 정수 저장   

        if (randomNumber == 0)
        { //랜덤 숫자가 0일때

            HorizontalDirection = 1; //공의 방향을 오른쪽으로 변화
        }
        else //랜덤 숫자가 1이 아닐때
        {
            HorizontalDirection = 0; //공의 뱡향을 왼쪽으로 설정
        }

        VerticalDirection = 1; //공의 상하 방향을 아래로 설정

        Rigidbody.velocity = new Vector2(Speed * HorizontalDirection, Speed * VerticalDirection);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall") { //내가 충돌한 물체의 tag가 Wall 이라면

            VerticalDirection *= -1; //상하 방향 반전

        }

        if (collision.transform.tag == "Player") { //충돌한 물체의 tag가 Player라면
            HorizontalDirection *= -1; //좌우 뱡향 반전
        }

        //공의 속도를 변경
        Rigidbody.velocity = new Vector2(Speed * HorizontalDirection, Speed * VerticalDirection);
    }
}
