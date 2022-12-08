using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    PursueTargetState pursueTargetState;

    // 목표를 감지할 수 있는 레이어
    [Header("Detection Layer")]
    [SerializeField] LayerMask detectionLayer;      // 탐지할 레이어계층
    // 목표를 감지할 수 있는 범위
    [Header("Detection Radius")]
    [SerializeField] float detectionRadius = 5;     // 탐지할 구체의 반지름
    // 목표를 감지할 수 있는 시야각
    [Header("Detection Angle Radius")]
    [SerializeField] float minimumDetectionRadiusAngle =  - 35f;
    [SerializeField] float maximumDetectionRadiusAngle =  - 35f;

    // We make our character idle until the find a potential target
    // If a target ist found we proceed to the "PursueTarget" state
    // IF no target is found we remain in the idle position

    private void Awake(){
        pursueTargetState = GetComponent<PursueTargetState>();
    }

    // ZomMov.cs를 매개변수로 받은 Tick을 오버라이드한 변수
    public override State Tick(ZomMov zomMov){
        if(zomMov.currentTarget != null){       // zomMov.currentTarget이 있을 경우
            return pursueTargetState;           // 쫓는다
        }else{
            FIndATargetViaLineOfSight(zomMov);  // 없는 경우 주변을 탐색하는 함수 사용
            return this;
        }
    }
        // 좀비의 주변 반경에서 플레이어 컴포넌트가 포함 된 콜라이더를  탐색하는 함수
    private void FIndATargetViaLineOfSight(ZomMov zomMov){
        // detectionLayer의 detectionRadius 반경 내에 있는 모든  콜라이더 탐색
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);
        
        // 충돌한 모든 콜라이더 중 플레이어무브먼트의 콜라이더를 찾는다.
        for(int i = 0; i < colliders.Length; i++){
            PlayerMovement player = colliders[i].transform.GetComponent<PlayerMovement>();
            if(player != null){     // 플레이어 변수에 콜라이더가 들어있다면
                                    // 플레이어가 현재대상의 앞의 시야각 안에 있을 경우를 확인
                Vector3 targetDirection = transform.position - player.transform.position;
                // 다른 2개 오브젝트의 방향성 벡터를 구하고 이 사이의 각도를 구하는 함수
                // Angle(시작점, 도착점); 두 벡터 사이의 가능한 각도중 작은 각도를 반환한다.(180도 이내)
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
                
                if(viewableAngle > minimumDetectionRadiusAngle && viewableAngle < maximumDetectionRadiusAngle){
                    
                    zomMov.currentTarget = player;
                }
            }
        }
    }
}
