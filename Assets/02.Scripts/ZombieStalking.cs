using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieStalking : MonoBehaviour
{
    // 좀비 스토킹 AI 
    // 쫓을 대상, 네비메쉬 오브젝트, 좀비오브젝트, 쫓는상태여부 
    public GameObject stalkerDest;
    NavMeshAgent ZombieAgent;
    public GameObject Zombie;
    public static bool isStalking;
    // 플레이어콜라이더, 맞는 화면, 공격여부, 플레이어와 접촉여부 
    public GameObject PlayerCol;
    public GameObject theFlash;
    public bool isAttack;
    public bool EnterPlayer;

    void Start() {
        // 메쉬컴포넌트 가져오기
        ZombieAgent = GetComponent<NavMeshAgent>();
        isStalking = false; // 시작 시 기본상태 
    }

    void Update(){
        // 쫓는 상태가 아니면 Idle 재생, 쫓는상태일경우 Walk재생, SetDestination으로 쫓을 대상의 위치로 이동
        if(isStalking == false){
            Zombie.GetComponent<Animator>().Play("Idle");
        }else{
            // 공격상태 x && 플레이어와 접촉중일 경우 공격 코루틴 실행
            if(EnterPlayer == true){
                ZombieAgent.ResetPath();
                if(isAttack == false){
                        StartCoroutine(AttackZ());
                    }
            }else{
                // SetDestination & 애니메이터로 Player를 쫓음 >> 접촉 시 공격 코루틴 실행
                Zombie.GetComponent<Animator>().Play("Z_Walk_InPlace");
                ZombieAgent.SetDestination(stalkerDest.transform.position);
                if(EnterPlayer == true){
                    ZombieAgent.ResetPath();
                    if(isAttack == false){
                        StartCoroutine(AttackZ());
                    }
                }
            }   
        }
    }

    // 접촉 확인 트리거
    void OnTriggerStay(Collider other) {
        if(other.gameObject == PlayerCol){
            EnterPlayer = true;
        }  
    }
    void OnTriggerExit(Collider other) {
        if(other.gameObject == PlayerCol){
            EnterPlayer = false;
        }  
    }
    // 공격상태 애니메이션 실행, 맞는화면실행, 체력 깍고 쫓는상태 재실행 후 공격상태 종료
    IEnumerator AttackZ(){
        isAttack = true;
        Zombie.GetComponent<Animator>().Play("Z_Attack");
        theFlash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        theFlash.SetActive(false);
        yield return new WaitForSeconds(.25f);
        GlobalHealth.currentHealt -= 5;
        yield return new WaitForSeconds(2.5f);
        Zombie.GetComponent<Animator>().Play("Z_Walk_InPlace");
        ZombieAgent.SetDestination(stalkerDest.transform.position);
        isAttack = false;
    }
}
