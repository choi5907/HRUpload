using UnityEngine;

// 플레이어 조작을 위한 사용자의 입력 감지
// 입력값을 다른 컴포넌트에서 사용할 수 있음
public class PlayerInput : MonoBehaviour
{
    // InputManager에 정해둔 이름 값을 가져옴
    public string verAxisName = "Vertical";     // 키보드 앞뒤
    public string horAxisName = "Horizontal";   // 키보드 좌우
    public string xRotation = "Mouse X";        // 마우스 x축
    public string yRotation = "Mouse Y";        // 마우스 Y축
   
    // 값 할당을 해당 스크립트에서 하는 프로퍼티
    public float ver { get; private set; }
    public float hor { get; private set; }
    public float xms { get; private set; }
    public float yms { get; private set; }

    // 프로퍼티의 입력 감지 부분
    public void Update(){
        ver = Input.GetAxis(verAxisName);
        hor = Input.GetAxis(horAxisName);
        xms = Input.GetAxis(xRotation);
        yms = Input.GetAxis(yRotation);
    }
}

