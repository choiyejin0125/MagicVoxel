using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//복셀을 랜덤한 방향으로 날아가게 하기
//필요속성: 날아갈 속도
public class Voxel : MonoBehaviour
{
    //복셀이 날아갈 속도 속성
    public float speed = 5;
    //일정 시간이 지나면 복셀 제거
    //필요속성: 복셀을 제거할 시간, 경과시간
    public float destoryTime = 3.0f;
    float currentTime;

    // void Start()
    void OnEnable()
    {
        currentTime = 0;
        //랜덤한 방향 찾기
        Vector3 direction = Random.insideUnitSphere; //크기가 1이고 방향만 존재함
        //랜덤한 방향으로 날아가는 속도주기
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
    }

    void Update()
    {
        //일정 시간이 지나면 복셀 제거
        //시간
        currentTime += Time.deltaTime;
        //제거 시간이 됨
        //만약 경과 시간이 제거 시간을 초과했다면
        if (currentTime > destoryTime)
        {
            //3. Voxel을 비활성화시킨다.
            gameObject.SetActive(false);
            //4. 오브젝트 풀에 다시 넣어준다.
            VoxelMaker.voxelPool.Add(gameObject);
            //복셀제거
            //Destroy(gameObject);
        }
    }
}