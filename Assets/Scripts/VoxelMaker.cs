using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    //생성할 대상 등록
    public GameObject voxelFactory;

    //오브젝트 풀의 크기
    public int voxelPoolSize = 20;

    //오브젝트 풀
    //static
    public static List<GameObject> voxelPool = new List<GameObject>();

    //생성 시간
    public float createTime = 0.1f;
    //경과 시간
    float currentTime = 0;

    void Start()
    {
        for (int i =0; i<voxelPoolSize; i++)
        {
            //1.복셀 공장에서 복셀 생성하기
            GameObject voxel = Instantiate(voxelFactory);
    // voxel.Renderer = 랜덤한 색
    voxel.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value); //랜덤한 색상 적용

            //2.복셀 비활성화
            voxel.SetActive(false);
            //3.복셀 오브젝트 풀에 담기
            voxelPool.Add(voxel);
        }
    }

    void Update()
    {
        // 생성 시간마다 복셀을 만들고 싶다.
        // 1. 경과 시간이 흐른다.
        currentTime += Time.deltaTime;
        // 2. 경과 시간이 생성 시간을 초과했다면
        if (currentTime > createTime)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            //3. Ray를 쏜다.
            if (Physics.Raycast(ray, out hitInfo))
            {
                // 복셀 오브젝트 풀 이용하기
                // 1. 만약 오브젝트 풀에 복셀이 있다면
                if(voxelPool.Count > 0)
                {
                    GameObject voxel = voxelPool[0];  //오브젝트 풀 최상단의 값을 가져옴
                    voxel.SetActive(true);             //객체를 활성화함
                    voxel.transform.position = hitInfo.point; //RayCast를 통해 얻은 충돌지점의 위치로 객체를 이동
                    voxelPool.RemoveAt(0);             //오브젝트 풀에서 Voxel 1개 제거
                    // 복셀을 생성했을 때만 경과 시간을 초기화 해줬다.
                    currentTime = 0;
                }
            }
        }
    }
}
