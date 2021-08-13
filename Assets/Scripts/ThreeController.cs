using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ThreeController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                // daha �nce se�ilmi� bir top var m�
                if (GameManager.Instance.AnySelectedBall == false)
                {
                    //Tube tag� olan bir objeye t�kland� m�?
                    if (hit.transform.tag == "Tube")
                    {
                        // Se�ilen t�p�n ismine g�re hangi listeden top se�ilecek? 
                        if (hit.transform.name == "Tube1") SelectBall("BallList1");
                        else if (hit.transform.name == "Tube2") SelectBall("BallList2");
                        else if (hit.transform.name == "Tube3") SelectBall("BallList3");
                    }
                }
                // daha �nce se�ilmi� bir top varsa 
                else
                {
                    //Tube tag� olan bir objeye t�kland� m�?
                    if (hit.transform.tag == "Tube")
                    {
                        // Se�ilen t�p�n ismine g�re hangi t�pe top g�t�r�lecek?

                        if (hit.transform.name == "Tube1") MoveToTubeBall("BallList1");
                        else if (hit.transform.name == "Tube2") MoveToTubeBall("BallList2");
                        else if (hit.transform.name == "Tube3") MoveToTubeBall("BallList3");
                    }
                }
            }
        }
    }

    //TOP SE��L�YOR
    void SelectBall(string listName)
    {
        if (listName == "BallList1") // e�er se�ilen birinci listeyse 
        {
            if (GameManager.Instance.BallList1.Count > 0) // Liste bo� de�ilse 
            {
                int lastBallIndex = GameManager.Instance.BallList1.Count - 1; // son eleman�n indexi 
                GameManager.Instance.CurrentBall = GameManager.Instance.BallList1[lastBallIndex]; // se�ilen(current) de�i�kene son topu ekleme 

                GameManager.Instance.BallList1.RemoveAt(lastBallIndex); // t�pten topu silme 
                GameManager.Instance.AnySelectedBall = true; // �u an top se�ildi�ini true yapma
            }
        }

        //D��ER T�PLERDEN SE��LENLER ���N AYNI ��LEMLER YAPILIYOR
        else if (listName == "BallList2")
        {
            if (GameManager.Instance.BallList2.Count > 0)
            {
                int lastBallIndex = GameManager.Instance.BallList2.Count - 1;
                GameManager.Instance.CurrentBall = GameManager.Instance.BallList2[lastBallIndex];
                GameManager.Instance.BallList2.RemoveAt(lastBallIndex);

                GameManager.Instance.AnySelectedBall = true;
            }

        }
        else if (listName == "BallList3")
        {
            if (GameManager.Instance.BallList3.Count > 0)
            {
                int lastBallIndex = GameManager.Instance.BallList3.Count - 1;
                GameManager.Instance.CurrentBall = GameManager.Instance.BallList3[lastBallIndex];
                GameManager.Instance.BallList3.RemoveAt(lastBallIndex);
                GameManager.Instance.AnySelectedBall = true;
            }
        }
        MoveToUpBall();
    }

    void MoveToUpBall()
    {
        //Yukar� hareket
        //GameManager.Instance.CurrentBall.transform.Translate(Vector3.up * 1f);
        GameManager.Instance.CurrentBall.transform.DOMoveY(1.70f, 0.2f);
    }

    //TOP G�T�R�L�YOR
    void MoveToTubeBall(string listName)
    {
        //D��ER L�STELER ���N AYNISI
        if (listName == "BallList1")
        {
            if (GameManager.Instance.BallList1.Count < 4)
            {
                GameManager.Instance.AnySelectedBall = false;

                //GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube2.transform.position;
                if (GameManager.Instance.BallList1.Count == 0)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.65f, 1);
                }
                else if (GameManager.Instance.BallList1.Count == 1)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.84f, 1);
                }
                else if (GameManager.Instance.BallList1.Count == 2)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.03f, 1);
                }
                else
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.22f, 1);
                }

                GameManager.Instance.BallList1.Add(GameManager.Instance.CurrentBall);

                GameManager.Instance.CurrentBall = null;
            }
        }
        else if (listName == "BallList2")
        {
            if (GameManager.Instance.BallList2.Count < 4)
            {
                GameManager.Instance.AnySelectedBall = false;

                //GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube3.transform.position;
                if (GameManager.Instance.BallList2.Count == 0)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.65f, 1);
                }
                else if (GameManager.Instance.BallList2.Count == 1)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.84f, 1);
                }
                else if (GameManager.Instance.BallList2.Count == 2)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.03f, 1);
                }
                else
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.22f, 1);
                }

                GameManager.Instance.BallList2.Add(GameManager.Instance.CurrentBall);

                GameManager.Instance.CurrentBall = null;
            }
        }

        else if (listName == "BallList3")
        {
            if (GameManager.Instance.BallList3.Count < 4)
            {
                GameManager.Instance.AnySelectedBall = false;

                //GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube3.transform.position;
                if (GameManager.Instance.BallList3.Count == 0)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.65f, 1);
                }
                else if (GameManager.Instance.BallList3.Count == 1)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.84f, 1);
                }
                else if (GameManager.Instance.BallList3.Count == 2)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.03f, 1);
                }
                else
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.22f, 1);
                }

                GameManager.Instance.BallList3.Add(GameManager.Instance.CurrentBall);

                GameManager.Instance.CurrentBall = null;
            }
        }
    }

    IEnumerator bekle()
    {
        yield return new WaitForSecondsRealtime(0.2f);
    }
}
