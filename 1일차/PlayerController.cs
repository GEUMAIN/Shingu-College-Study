using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 5.0f; //플레이어 속도

    
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)) //위쪽 화살표를 누르고 있을때
        {
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow)) //위쪽 화살표를 누르고 있을때
        {
            transform.Translate(Vector2.down * Speed * Time.deltaTime);
        }

        if (transform.position.y > 3)
        { //오브젝트의 y 좌표가 최대 높이 3보다 클 때
            transform.position = new Vector2(transform.position.x, 3); // y좌표의 최대높이로 이동
        }

        if (transform.position.y < -3)
        { //오브젝트의 y 좌표가 최대 높이 -3보다 작을 때
            transform.position = new Vector2(transform.position.x, -3); // y좌표의 최저높이로 이동
        }
    }
}
