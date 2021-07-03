using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameControl : MonoBehaviour
{
    GameObject choseObject;
    Material choseMaterial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PutSphereToHole();
    }

    void PutSphereToHole()
    {
        float maxDis = 10;
        RaycastHit raycastHit;
        Ray targetRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (!Physics.Raycast(targetRay, out raycastHit, maxDis)) { return; }

            choseObject = raycastHit.collider.gameObject;

            if (!choseObject.CompareTag("Sphere")) {
                choseMaterial = null;
                return;
            }
            choseMaterial = choseObject.GetComponent<Renderer>().material;
            Debug.Log("Get Material");

        }

        if (Input.GetMouseButtonUp(0))
        {
            if (choseMaterial == null) { return; }

            if (!Physics.Raycast(targetRay, out raycastHit, maxDis)) { return; }

            choseObject = raycastHit.collider.gameObject;

            if (!choseObject.CompareTag("Hole")) { return; }
            choseObject.GetComponent<Renderer>().material = choseMaterial;

        }
    }

    void 
}
