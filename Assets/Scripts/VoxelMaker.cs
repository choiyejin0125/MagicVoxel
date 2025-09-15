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
    void Start()
    {   
        for (int i =0; i<voxelPoolSize; i++)
        {
            //1.복셀 공장에서 복셀 생성하기
            GameObject voxel = Instantiate(voxelFactory);
            // voxel.Randerer = 랜덤한 색
            //2.복셀 비활성화
            voxel.SetActive(false);
            //3.복셀 오브젝트 풀에 담기
            voxelPool.Add(voxel);
        }

    }

    void Update()
    {   
        //1.사용자가 마우스 클릭하면
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            //2.마우스의 위치가 바닥 위에 위치해 있다면
            if (Physics.Raycast(ray, out hitInfo))
            {   
                if(voxelPool.Count>0) //오브젝트 풀 안에 voxel이 있는지 확인인
                {
                    GameObject voxel = voxelPool[0];            //오브젝트 풀 최상단의 값을 가져옴옴
                    voxel.SetActive(true);                      //객체를 활성화함
                    voxel.transform.position = hitInfo.point;   //RayCast를 통해 얻은 충돌지점의 위치로 객체를 이동동
                    voxelPool.RemoveAt(0);                      //오브젝트 풀에서 Voxel 1개 제거거
                }
            }
        }
    }
}
