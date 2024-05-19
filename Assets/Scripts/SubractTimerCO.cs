using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubractTimerCO : MonoBehaviour
{

    public float theDistance;
    // public GameObject actionKey; //Text yazıları

    public GameObject subractTimerObject;

    public float timerDuration = 5f;
    public Timer timer;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        theDistance = PlayerRay.distanceFromTarget;

        // E tuşuna basıldığında objeyi yok et ve timer'a 5 sn ekle

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
            if (theDistance <= 5)
            {
                this.gameObject.GetComponent<BoxCollider>().enabled = false;

                if (timer.remainingTime <= 5)
                {
                    timer.remainingTime = 0;
                }

                timer.SubractTime(timerDuration);
                Destroy(subractTimerObject);
            }



        }
    }


}
