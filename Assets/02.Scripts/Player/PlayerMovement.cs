using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// playerInput을 받아 캐릭터 움직임
public class PlayerMovement : MonoBehaviour
{
    // 컴포넌트 가져오기
    public PlayerInput playerInput; // 입력 컴포넌트
    [SerializeField]
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    [SerializeField]
    private float walkSpeed; // 움직이는 속도
    [SerializeField]
    private float lookSensitivity;
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX;
    [SerializeField]
    private Camera theCamera;

    private void Start(){
        // 시작 시 사용할 컴포넌트 가져옴
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        // 마우스 커서 중앙에 고정, 마우스 커서 숨기기
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    private void Update(){
        // 키보드 입력으로 상하좌우 움직임
        // 마우스로 화면과 캐릭터를 회전
        Move();
        CameraRotation();
        CharacterRotation();
    }
    private void Move(){
        // playerInput 컴포넌트의 키보드 입력값을 가져온다
        //  방향을 나타내는 이동 벡터값 transform.right 좌우/x축, transform.forward 앞뒤/y축
        Vector3 moveVel = playerInput.hor * transform.right + playerInput.ver * transform.forward;

        // 대각선 이동을 위해 정규화 Vector 함수 대입에 .normalize 사용하거나
        // 함수.normalize를 사용한다
        Vector3 MoveVel = moveVel.normalized * walkSpeed;

        // movePosition으로 이동, 초당 움직임을 위해 deltaTime 사용
        playerRigidbody.MovePosition(playerRigidbody.position + MoveVel * Time.deltaTime);
    }
    private void CameraRotation(){
        float cRotationX = playerInput.yms * lookSensitivity;
        
        currentCameraRotationX -= cRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }
    private void CharacterRotation(){
        float cRotationY = playerInput.xms;
        Vector3 characterRotationY = new Vector3(0f, cRotationY, 0f) * lookSensitivity;
        playerRigidbody.MoveRotation(playerRigidbody.rotation * Quaternion.Euler(characterRotationY));
    }
}
