using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GeneralController controller;
    public EndGame end;
    public Text pausetable;
    public void OnCollisionEnter(Collision col)
    {
            controller.enabled = false;
            Debug.Log("Girdi");
            end.gameoverscene.SetActive(true);
            var rectpausetable = pausetable.GetComponent<RectTransform>();
            rectpausetable.anchoredPosition = new Vector3(922.93f, -348f, 0f);
    }
}
