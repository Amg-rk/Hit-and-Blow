using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAnswer : MonoBehaviour
{
    [SerializeField] Material[] materials;
    [SerializeField] Renderer[] answerSphereRenderers;

    Material[] answerMaterials;
    public Material[] AnswerMaterials{
        get { return answerMaterials;  }
        private set { }
    }

    const int spheresNumber = 6;
    const int answerMaterialsNumber = 4;

    // Start is called before the first frame update
    void Start()
    {
        answerMaterials = new Material[answerMaterialsNumber];
        int[] answerMaterialNumbers = new int[answerMaterialsNumber];
        int rand;

        for(int i=0; i < answerMaterialsNumber; i++)
        {
            rand = Random.Range(0, spheresNumber - 1);

            while (System.Array.Exists(answerMaterialNumbers,
                element => element == rand))
            {
                rand = Random.Range(0, spheresNumber - 1);
            }

            answerMaterialNumbers[i] = rand;
            answerMaterials[i] = materials[rand];
            answerSphereRenderers[i].material = materials[rand];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
