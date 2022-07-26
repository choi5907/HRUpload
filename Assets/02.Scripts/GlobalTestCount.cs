using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobalTestCount : MonoBehaviour
{
    // 시험직 개수, 캐비넷 시험지 개수, UI시험지 개수, 함수용 시험지개수 변수
    public static int TestCount;
    public static int CaseTestCount;
    public GameObject TestDisplay;
    public int internalTest;
    void Update()
    {
        internalTest = TestCount;
        TestDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "" + internalTest;
    }
}
