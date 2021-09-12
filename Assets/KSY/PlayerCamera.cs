using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    // ī�޶� ���� ��ġ ( �÷��̾� �� ��ġ )
    public Transform playerEye;
    // ī�޶� ȸ�� �ӵ�
    public float rotSpeed = 200;
    public float h; // ���콺 X��
    public float v; // ���콺 Y��
    public float mx; // ���콺 X����
    public float my; // ���콺 Y����

    private void FixedUpdate()
    {
        CameraView();
    }

    // ī�޶� ���� ��ġ�� ����
    void CameraView()
    {
        transform.position = playerEye.position;
        transform.rotation = playerEye.rotation;

        h = Input.GetAxis("Mouse X"); // ���콺�� X�� ������
        v = Input.GetAxis("Mouse Y"); // ���콺�� Y�� ������

        mx += h * rotSpeed * Time.deltaTime;
        my += v * rotSpeed * Time.deltaTime;

        if(my >= 90 & mx >= 90) // Y�� ������ 90�� �̻��̸�
        {
            my = 90; // Y�� ������ 90���� ����
            mx = 90; // X�� ������ 90���� ����
        }
        else if(my <= -90 & mx >= 90) // Y�� ������ 90�� �����̸�
        {
            my = -90; // Y�� ������ -90���� ����
            mx = -90; // X�� ������ -90���� ����
        }
        transform.eulerAngles = new Vector3(-my, -mx, 0); // �ȼ��� ��ȣ�� ���Ʒ� �ݴ��̹Ƿ�
        my = Mathf.Clamp(my, -90, 90); // my�� ������ �ּҰ� -90���� �ִ밪 90����
    }
}
