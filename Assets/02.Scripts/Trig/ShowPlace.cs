using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowPlace : MonoBehaviour
{
    // 교무실, 교실, 보건실, 도서관 위치콜라이더
    public GameObject PlaceObject; // 콜라이더묶음
    public GameObject OfficeCol;
    public GameObject ClassCol;
    public GameObject InfirmaryCol;
    public GameObject LibraryCol;
    public GameObject PlaceDisplay; // 위치텍스트
    public GameObject PlayerCol;
    
    void Start() {
        OfficeCol = PlaceObject.transform.GetChild(0).gameObject;
        ClassCol = PlaceObject.transform.GetChild(1).gameObject;
        InfirmaryCol = PlaceObject.transform.GetChild(2).gameObject;
        LibraryCol = PlaceObject.transform.GetChild(3).gameObject;
    }

    void OnTriggerEnter(Collider other) {
        if(this.gameObject == OfficeCol)
            PlaceDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "교무실";
        if(this.gameObject == ClassCol)
            PlaceDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "교실";
        if(this.gameObject == LibraryCol)
            PlaceDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "도서관";
        if(this.gameObject == InfirmaryCol)
            PlaceDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "보건실";
        if(other.gameObject == PlayerCol)
            StartCoroutine(PlaceShow());
    }
    IEnumerator PlaceShow(){
        PlaceDisplay.SetActive(true);
        yield return new WaitForSeconds(2f);
        PlaceDisplay.SetActive(false);
    }
}
