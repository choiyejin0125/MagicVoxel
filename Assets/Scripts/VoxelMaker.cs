using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{   
    //생성할 대상 등록
    public GameObject voxelFactory;
    void Start()
    {
        
    }

    // Update is called once per frame
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
                //3.복셀 공장에서 복셀을 만들어야 한다.
                GameObject voxel = Instantiate(voxelFactory);
                //4.복셀을 배치하고 싶다
                voxel.transform.position = hitInfo.point;
            }
        }
    }
}
