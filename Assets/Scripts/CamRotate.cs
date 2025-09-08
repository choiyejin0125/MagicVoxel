using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{   
    //현재각도
    Vector3 angle;
    //마우스 감도
    public float sensitibity = 200;

    void Start()
    {   
        //시작할 때 현재 카메라 각도 적용
        angle=Camera.main.transform.eulerAngles;
        //카메라 반전시키기
        angle.x *= -1;
    }


    //마우스 입력에 따라 카메라 회전 시키기
    void Update()
    {
        //마우스 정보 입력
        //마우스 좌우 입력 받기
        float x= Input.GetAxis("Mouse Y");
        float y= Input.GetAxis("Mouse X");

        //방향 확인
        //카메라 민감도와 시간 넣기
        angle.x += x*sensitibity*Time.deltaTime;
        angle.y += y*sensitibity*Time.deltaTime;
        //angle.z = transform.eulerAngles.z

        //최댓값 최소값 넣기
        angle.x = Mathf.Clamp(angle.x, -90,90);
        
        //회전
        //카메라의 회전 값에 새로 만들어진 회전 값을 할당
        transform.eulerAngles =new Vector3(-angle.x,angle.y,transform.eulerAngles.z);
        
    }
}
