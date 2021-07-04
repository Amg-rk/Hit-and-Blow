using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReloadEventManager : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Transform reloadButtonTrans;
    [SerializeField] Transform showAnswerButtonTrans;
    [SerializeField] GameControl gameControl;

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 clickPos = (Vector2)Camera.main.ScreenToWorldPoint(eventData.position);

        if ((clickPos - (Vector2)reloadButtonTrans.position).SqrMagnitude() < 1.5f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if((clickPos - (Vector2)showAnswerButtonTrans.position).SqrMagnitude() < 1.5f)
        {
            gameControl.ShowAnswer();
        }
        //Debug.Log($"click:{Camera.main.ScreenToWorldPoint(eventData.position)}");
    }
}
