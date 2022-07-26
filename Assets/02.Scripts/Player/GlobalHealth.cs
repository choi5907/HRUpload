using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour
{
    // 체력 static 15, Update에서 static변수의 15값을 받아 0이되면 게임오버씬으로 이동
    public static int currentHealt = 15;
    public int internalHealth;
    void Update()
    {
        internalHealth = currentHealt;
        if(currentHealt <= 0){
            SceneManager.LoadScene(4);
        }
    }
}
