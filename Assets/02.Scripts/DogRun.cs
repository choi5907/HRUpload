using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogRun : MonoBehaviour
{
    public GameObject Dog;
    public GameObject DogCol;
    private Animator dogAni;
    void Start() {
        dogAni = Dog.GetComponent<Animator>();
        StartCoroutine(dogRun());
    }
    
    IEnumerator dogRun(){
        yield return new WaitForSeconds(9.5f);
        dogAni.Play("run");
        yield return new WaitForSeconds(9.5f);
        DogCol.GetComponent<BoxCollider>().enabled = false;
        Dog.SetActive(false);
    }
}
