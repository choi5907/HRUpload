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

    [SerializeField] bool hasTarget;
    public override State Tick(){
        if(hasTarget){
            Debug.Log("We have found a target");
            return pursueTargetState;
        }else{
            Debug.Log("We have no target yet.");
            return this;
        }
    }

    private void FIndATargetViaLineOfSight(){
        // detectionLayer의 detectionRadius 반경 내에 있는 모든  콜라이더 탐색
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);
        
        // 충돌한 모든 콜라이더 중 플레이어무브먼트의 콜라이더를 찾는다.
        for(int i = 0; i < colliders.Length; i++){
            PlayerMovement player = colliders[i].transform.GetComponent<PlayerMovement>();
            
            // 플레이어무브먼트가 감지되면 시야를 확인
            if(player != null){
                // 플레이어가 현재대상의 앞에 있을 경우
                Vector3 targetDirection = transform.position - player.transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                if(viewableAngle > minimumDetectionRadiusAngle && viewableAngle < maximumDetectionRadiusAngle){
                    
                }
            }
        }
    }
}
