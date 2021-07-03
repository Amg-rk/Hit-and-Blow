using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAnswer : MonoBehaviour
{
    [SerializeField] Material[] materials;

    [SerializeField] Renderer[] answerSphereRenderers;
    public Renderer[] AnswerSphereRenderers
    {
        get { return answerSphereRenderers; }
        private set { }
    }

    Material[] answerMaterials;
    public Material[] AnswerMaterials{
        get { return answerMaterials;  }
        private set { }
    }

    int spheresNumber = 6;
    int answerMaterialsNumber = 4;
    public int AnswerMaterialsNumber
    {
        get { return answerMaterialsNumber; }
        private set { }
    }

    void Start()
    {
        answerMaterials = new Material[answerMaterialsNumber];
        int[] answerMaterialNumbers = new int[answerMaterialsNumber];
        int rand;

        for (int i=0; i < answerMaterialsNumber; i++)
        {
            rand = Random.Range(0, spheresNumber - 1);

            while (System.Array.Exists(answerMaterialNumbers,
                element => element == rand))
            {
                rand = Random.Range(0, spheresNumber - 1);
            }

            answerMaterialNumbers[i] = rand;
            answerMaterials[i] = materials[rand];
        }
    }

    void Update()
    {
        
    }
}
