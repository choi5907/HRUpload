using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour
{
    // Raycast를 담을 변수, static변수 선언
    public static float DistanceFromTarget;
    public float Totarget;

    // 주기적으로 거리정보 갱신
    private void Update() {
        RaycastHit Hit;
        // 충돌 거리를 static 변수에 담는다.
        // 실제 충돌 정보가 저장되었을 때만 실행
        // transform.TransformDirection : 로컬 벡터를 월드 벡터로 바꾸어 준다.
        // Raycast(transform.position, transform.forward) origin, direction, hit info
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit)){
            Totarget = Hit.distance;    // 원점 ~ 충돌 지점까지의 거리
            DistanceFromTarget = Totarget;  // static에 저장
        }
    }
}
