using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public string h = "Horizontal";
    public float hInput;
    public float playerMoveSpeed = 10; // 움직임 스피드
    public float jumpPower = 5; // 점프 파워

    float gravity = -9.8f;
    float yVelocity; // 중력

    CharacterController CC;

    // 플레이어 오른손에 방망이
    public GameObject bath;

    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        MoveCtrl();
        WeaponShow();
    }

    void MoveCtrl()
    {
        hInput = Input.GetAxis(h);

        Vector3 dir = new Vector3(hInput, 0, 0);
        dir.Normalize(); // 정규화

        // 중력
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;
        //transform.position += dir * playerMoveSpeed * Time.deltaTime;
        CC.Move(dir * playerMoveSpeed * Time.deltaTime);
        

        // 점프
        if(Input.GetButtonDown("Jump"))
        {
            yVelocity = jumpPower;
        }
    }

    void WeaponShow()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LHand))
        {
            bath.SetActive(true);
        }
    }
}
