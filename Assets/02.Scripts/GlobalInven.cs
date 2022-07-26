using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInven : MonoBehaviour
{
    // 교실 키, 보건실 키
    public static bool ClassKey = false;
    public static bool InfiKey = false;
    public bool internalClassKey = false;
    public bool internalInfiKey = false;
    void Update()
    {
        internalClassKey = ClassKey;
        internalInfiKey = InfiKey;
    }
}
