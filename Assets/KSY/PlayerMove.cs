using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public string h = "Horizontal";
    public float hInput;
    public float playerMoveSpeed = 10; // ������ ���ǵ�
    public float jumpPower = 5; // ���� �Ŀ�

    float gravity = -9.8f;
    float yVelocity; // �߷�

    CharacterController CC;

    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        MoveCtrl();
    }

    void MoveCtrl()
    {
        hInput = Input.GetAxis(h);

        Vector3 dir = new Vector3(hInput, 0, 0);
        dir.Normalize(); // ����ȭ

        // �߷�
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        //transform.position += dir * playerMoveSpeed * Time.deltaTime;
        CC.Move(dir * playerMoveSpeed * Time.deltaTime);
        

        // ����
        if(Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
        }
    }
}