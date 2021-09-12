using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // 카메라가 있을 위치 ( 플레이어 눈 위치 )
    public Transform playerEye;
    // 카메라 회전 속도
    public float rotSpeed = 200;
    public float h; // 마우스 X축
    public float v; // 마우스 Y축
    public float mx; // 마우스 X각도
    public float my; // 마우스 Y각도

    private void FixedUpdate()
    {
        CameraView();
    }

    // 카메라가 있을 위치와 방향
    void CameraView()
    {
        transform.position = playerEye.position;
        transform.rotation = playerEye.rotation;

        h = Input.GetAxis("Mouse X"); // 마우스의 X축 움직임
        v = Input.GetAxis("Mouse Y"); // 마우스의 Y축 움직임

        mx += h * rotSpeed * Time.deltaTime;
        my += v * rotSpeed * Time.deltaTime;

        if(my >= 90 & mx >= 90) // Y축 각도가 90도 이상이면
        {
            my = 90; // Y축 각도를 90도로 지정
            mx = 90; // X축 각도를 90도로 지정
        }
        else if(my <= -90 & mx >= 90) // Y축 각도가 90도 이하이면
        {
            my = -90; // Y축 각도를 -90도로 지정
            mx = -90; // X축 각도를 -90도로 지정
        }
        transform.eulerAngles = new Vector3(-my, -mx, 0); // 픽셀이 부호가 위아래 반대이므로
        my = Mathf.Clamp(my, -90, 90); // my의 범위가 최소값 -90부터 최대값 90까지
    }
}
