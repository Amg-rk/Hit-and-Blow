using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameControl : MonoBehaviour
{
    [SerializeField] Transform answerTrans;

    GameObject choseObject;
    Material choseMaterial;

    void Start()
    {

    }

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

    public void Clear()
    {
        Debug.Log("clear!");
        ShowAnswer();
    }

    void ShowAnswer()
    {
        CreateAnswer createAnswer = answerTrans.GetComponent<CreateAnswer>();
        for (int i=0; i < createAnswer.AnswerMaterialsNumber; i++)
        {
            createAnswer.AnswerSphereRenderers[i].material = createAnswer.AnswerMaterials[i];
        }
    }
}
