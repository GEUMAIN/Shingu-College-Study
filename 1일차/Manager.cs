using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Text TimeText;

    public GameObject BallPrefabs; //�� ���������� Prefabs
    public GameObject GameoverUI; //���� ���� UI

    private bool ballExists = false; //���� ������ ���� �����ϴ��� Ȯ���ϴ� bool ����
    private bool Play = false; //���� ������ ���������� Ȯ���ϴ� bool ����
    private float playTime = 0.0f; //���� ������ ���ڵ� �ð�


    void Start()
    {
        Play = true;
        ballExists = false;
        playTime = 0.0f;

    }

    void Update()
    {
        if (ballExists == false) { //���� ���� �������� ���� ��

            ballExists = true; //���� �����Ѵٰ� ����
            Instantiate(BallPrefabs, new Vector2(0, 2), Quaternion.identity); //���� �������� ����
        }

        if (Play && ballExists) { //���� �÷��� ���̰�, ���� ������ ��

            playTime += Time.deltaTime; //�÷��� Ÿ���� �������ְ�

            TimeText.text = "PlayTime :" + playTime.ToString("00.00"); //�÷��� Ÿ�� �ؽ�Ʈ�� ������Ʈ
        }

        if (!Play) {
            if (Input.anyKeyDown) {
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) //�ٸ� ��ü�� �浹 �� ���
    {
        if (collision.transform.tag == "Ball") { //�浹�� ��ü�� tag �� Ball �̸�
            Destroy(collision.gameObject); //�浹�� ��ü �ı�
            Play = false; //�÷������� false�� ����
            GameoverUI.SetActive(true); //���ӿ��� UI Ȱ��ȭ
        }
    }
}
