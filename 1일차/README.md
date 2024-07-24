### 1일차

### 기본적인 변수와 출력문, if문 for문

```csharp
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
```

---

### 플레이어 이동과 벽에 닿았을 때 공 튀기기

![sang - GameScene - Windows, Mac, Linux - Unity 2022 3 24f1 _DX11_ 2024-07-24 12-06-14](https://github.com/user-attachments/assets/2b3b607e-b8bb-4da6-ad46-495299958718)

---

### Manager

```csharp
public class Manager : MonoBehaviour
{
    public Text TimeText;

    public GameObject BallPrefabs; //공 오브젝츠의 Prefabs
    public GameObject GameoverUI; //게임 종류 UI

    private bool ballExists = false; //현재 씬에서 공지 존재하는지 확인하는 bool 변수
    private bool Play = false; //현재 게임이 진행중인지 확인하는 bool 변수
    private float playTime = 0.0f; //현재 게임이 진핸된 시간

    void Start()
    {
        Play = true;
        ballExists = false;
        playTime = 0.0f;

    }

    void Update()
    {
        if (ballExists == false) { //현재 공이 존재하지 않을 때

            ballExists = true; //공이 존재한다고 변경
            Instantiate(BallPrefabs, new Vector2(0, 2), Quaternion.identity); //공을 동적으로 생성
        }

        if (Play && ballExists) { //현재 플레이 중이고, 공이 존재할 때

            playTime += Time.deltaTime; //플레이 타임을 갱신해주고

            TimeText.text = "PlayTime :" + playTime.ToString("00.00"); //플레이 타임 텍스트에 업데이트
        }

        if (!Play) {
            if (Input.anyKeyDown) {
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //다른 물체와 충돌 할 경우
    {
        if (collision.transform.tag == "Ball") { //충돌한 물체의 tag 가 Ball 이면
            Destroy(collision.gameObject); //충돌한 물체 파괴
            Play = false; //플레이중을 false로 변경
            GameoverUI.SetActive(true); //게임오버 UI 활성화
        }
    }
}

```

---

### Ball (공 움직임)

```csharp
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
```

---

### 플레이어 이동

```csharp
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
```

---
