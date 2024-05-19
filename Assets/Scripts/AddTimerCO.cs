using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimerCO : MonoBehaviour
{
    public float theDistance;
    // public GameObject actionKey; //Text yazıları

    public GameObject addTimerObject;

    public float timerDuration = 5f;
    public Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

    }

    private void OnMouseOver()
    {
        if (theDistance <= 2)
        {
            //var ise textimiz burada aktif edeceğiz
        }
        else
        {
            //false kısımları burada
        }



        if (Input.GetKeyDown(KeyCode.E))
        {

            if (theDistance <= 5) //kontroller ile düzelt rakamı
            {
                // E tuşuna basıldığında objeyi yok et ve timer'a 5 sn ekle

                this.gameObject.GetComponent<BoxCollider>().enabled = false;

                timer.AddTime(timerDuration);
                Destroy(addTimerObject);



            }
        }
    }


}
