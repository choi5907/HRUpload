using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private bool ontrig; // 한번
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void Update(){
        if(SceneManager.GetActiveScene().name=="GameEnding" && ontrig == false){
            ontrig = true;
            StartCoroutine(WaitDestroy()); 
        }
    }
    IEnumerator WaitDestroy(){
        yield return new WaitForSeconds(10.5f);
        Destroy(this.gameObject);
    }
}
