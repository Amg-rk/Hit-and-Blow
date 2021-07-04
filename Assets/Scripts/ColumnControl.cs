using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnControl : MonoBehaviour
{
    [SerializeField] Transform hintObjectTrans;
    [SerializeField] Transform answerTrans;
    [SerializeField] Transform[] columnSphereTrans;
    [SerializeField] Transform[] hintSphereTrans;
    [SerializeField] Material hitMaterial;
    [SerializeField] Material blowMaterial;
    [SerializeField] GameControl gameControl;

    Material[] answerMaterials;
    Material[] columnMaterials;

    int answerMaterialsNumber;

    void Start()
    {
        answerMaterials = answerTrans.GetComponent<CreateAnswer>().AnswerMaterials;
        answerMaterialsNumber = answerTrans.GetComponent<CreateAnswer>().AnswerMaterialsNumber;
    }

    void Update()
    {
        JudgeButtonON();
    }

    void JudgeButtonON()
    {
        float maxDis = 10;
        RaycastHit raycastHit;
        Ray targetRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (!Physics.Raycast(targetRay, out raycastHit, maxDis)) { return; }

            if (raycastHit.collider.transform != hintObjectTrans) { return; }

            Judge();

        }
    }

    void Judge()
    {
        int hitCount = 0;
        int blowCount = 0;

        columnMaterials = new Material[answerMaterialsNumber];

        for (int i=0; i < answerMaterialsNumber; i++)
        {
            columnMaterials[i] = columnSphereTrans[i].GetComponent<Renderer>().material;
        }

        //Debug.Log($"1:{columnMaterials[0].name},2:{columnMaterials[1].name}," +
        //  $"3:{columnMaterials[2].name},4:{columnMaterials[3].name}");

        //Debug.Log($"1:{answerMaterials[0].name},2:{answerMaterials[1].name}," +
        //  $"3:{answerMaterials[2].name},4:{answerMaterials[3].name}");

        for (int i=0; i < answerMaterialsNumber; i++)
        {
            bool isBlow = false;
            bool isHit = false;
            for(int j=0; j < answerMaterialsNumber; j++)
            {
                if (answerMaterials[i].color == columnMaterials[j].color)
                {
                    if (i == j)
                    {
                        isHit = true;
                        break;
                    }
                    isBlow = true;
                }
            }
            if (isHit)
            {
                hitCount++;
                continue;
            }
            if (isBlow) { blowCount++; }

            /*
            if(System.Array.Exists(answerMaterials,
                element => element == columnMaterials[i]))
            {
                Debug.Log(columnMaterials[i].name);
                if (columnMaterials[i] == answerMaterials[i])
                {
                    hitCount++;
                }
                else
                {
                    blowCount++;
                }
            }
            */
        }

        ShowHint(hitCount, blowCount);
        //Debug.Log($"hit:{hitCount},blow:{blowCount}");

        if(hitCount == answerMaterialsNumber)
        {
            gameControl.Clear();
        }
    }

    void ShowHint(int hitCount, int blowCount)
    {
        for(int i=0; i < hitCount; i++)
        {
            hintSphereTrans[i].GetComponent<Renderer>().material = hitMaterial;
        }

        for (int j=hitCount; j < hitCount + blowCount; j++)
        {
            hintSphereTrans[j].GetComponent<Renderer>().material = blowMaterial;
        }
    }
}
