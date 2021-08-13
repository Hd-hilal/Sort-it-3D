using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewController : MonoBehaviour
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
                        else if (hit.transform.name == "Tube4") SelectBall("BallList4");
                        else if (hit.transform.name == "Tube5") SelectBall("BallList5");
                        else if (hit.transform.name == "Tube6") SelectBall("BallList6");
                        else if (hit.transform.name == "Tube7") SelectBall("BallList7");
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
                        else if (hit.transform.name == "Tube4") MoveToTubeBall("BallList4");
                        else if (hit.transform.name == "Tube5") MoveToTubeBall("BallList5");
                        else if (hit.transform.name == "Tube6") MoveToTubeBall("BallList6");
                        else if (hit.transform.name == "Tube7") MoveToTubeBall("BallList7");
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
        else if (listName == "BallList4")
        {
            if (GameManager.Instance.BallList4.Count > 0)
            {
                int lastBallIndex = GameManager.Instance.BallList4.Count - 1;
                GameManager.Instance.CurrentBall = GameManager.Instance.BallList4[lastBallIndex];
                GameManager.Instance.BallList4.RemoveAt(lastBallIndex);
                GameManager.Instance.AnySelectedBall = true;
            }
        }
        else if (listName == "BallList5")
        {
            if (GameManager.Instance.BallList5.Count > 0)
            {
                int lastBallIndex = GameManager.Instance.BallList5.Count - 1;
                GameManager.Instance.CurrentBall = GameManager.Instance.BallList5[lastBallIndex];
                GameManager.Instance.BallList5.RemoveAt(lastBallIndex);
                GameManager.Instance.AnySelectedBall = true;
            }
        }
        else if (listName == "BallList6")
        {
            if (GameManager.Instance.BallList6.Count > 0)
            {
                int lastBallIndex = GameManager.Instance.BallList6.Count - 1;
                GameManager.Instance.CurrentBall = GameManager.Instance.BallList6[lastBallIndex];
                GameManager.Instance.BallList6.RemoveAt(lastBallIndex);
                GameManager.Instance.AnySelectedBall = true;
            }
        }
        else if (listName == "BallList7")
        {
            if (GameManager.Instance.BallList7.Count > 0)
            {
                int lastBallIndex = GameManager.Instance.BallList7.Count - 1;
                GameManager.Instance.CurrentBall = GameManager.Instance.BallList7[lastBallIndex];
                GameManager.Instance.BallList7.RemoveAt(lastBallIndex);
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
        if (listName == "BallList1") // Se�ilen t�pe g�re hangi liste
        {
            if (GameManager.Instance.BallList1.Count < 4) // Se�ilen t�p dolu mu 
            {
                GameManager.Instance.AnySelectedBall = false; // Art�k se�ilen havada top yok  

                // BURAYI D�REKT YEN� T�P�N KONUMUNA SETLED�M SEN HANG� KONUMUNA G�DECE��N� YAPARSIN
                //GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube1.transform.position;
                if (GameManager.Instance.BallList1.Count == 0)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.65f, 1);
                }
                else if(GameManager.Instance.BallList1.Count == 1) 
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.84f, 1);
                }
                else if (GameManager.Instance.BallList1.Count == 2)
                { 
                    GameManager.Instance.CurrentBall.transform.DOMoveX(1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.03f, 1);
                }
                else
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.22f, 1);
                }
                GameManager.Instance.BallList1.Add(GameManager.Instance.CurrentBall); // Se�ilen top yeni t�p�n listesine eklendi
                //CurrentBall de�i�keni temizleniyor
                GameManager.Instance.CurrentBall = null;
            }

        }

        //D��ER L�STELER ���N AYNISI
        else if (listName == "BallList2")
        {
            if (GameManager.Instance.BallList2.Count < 4)
            {
                GameManager.Instance.AnySelectedBall = false;

                //GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube2.transform.position;
                if (GameManager.Instance.BallList2.Count == 0) 
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.65f, 1);
                }
                else if (GameManager.Instance.BallList2.Count == 1) 
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.84f, 1);
                }
                else if (GameManager.Instance.BallList2.Count == 2) 
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
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.65f, 1);
                }
                else if (GameManager.Instance.BallList3.Count == 1) 
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.84f, 1);
                }
                else if (GameManager.Instance.BallList3.Count == 2) 
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

                GameManager.Instance.BallList3.Add(GameManager.Instance.CurrentBall);

                GameManager.Instance.CurrentBall = null;
            }
        }
        else if (listName == "BallList4")
        {
            if (GameManager.Instance.BallList4.Count < 4)
            {
                GameManager.Instance.AnySelectedBall = false;

                //GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube3.transform.position;
                if (GameManager.Instance.BallList4.Count == 0)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.65f, 1);
                }
                else if (GameManager.Instance.BallList4.Count == 1)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.84f, 1);
                }
                else if (GameManager.Instance.BallList4.Count == 2)
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

                GameManager.Instance.BallList4.Add(GameManager.Instance.CurrentBall);

                GameManager.Instance.CurrentBall = null;
            }
        }
        else if (listName == "BallList5")
        {
            if (GameManager.Instance.BallList5.Count < 4)
            {
                GameManager.Instance.AnySelectedBall = false;

                //GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube3.transform.position;
                if (GameManager.Instance.BallList5.Count == 0)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.65f, 1);
                }
                else if (GameManager.Instance.BallList5.Count == 1)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.84f, 1);
                }
                else if (GameManager.Instance.BallList5.Count == 2)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.03f, 1);
                }
                else
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.22f, 1);
                }

                GameManager.Instance.BallList5.Add(GameManager.Instance.CurrentBall);

                GameManager.Instance.CurrentBall = null;
            }
        }
        else if (listName == "BallList6")
        {
            if (GameManager.Instance.BallList6.Count < 4)
            {
                GameManager.Instance.AnySelectedBall = false;

                //GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube3.transform.position;
                if (GameManager.Instance.BallList6.Count == 0)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-2.1f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.65f, 1);
                }
                else if (GameManager.Instance.BallList6.Count == 1)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-2.1f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.84f, 1);
                }
                else if (GameManager.Instance.BallList6.Count == 2)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-2.1f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.03f, 1);
                }
                else
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-2.1f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.22f, 1);
                }

                GameManager.Instance.BallList6.Add(GameManager.Instance.CurrentBall);

                GameManager.Instance.CurrentBall = null;
            }
        }
        else if (listName == "BallList7")
        {
            if (GameManager.Instance.BallList7.Count < 4)
            {
                GameManager.Instance.AnySelectedBall = false;

                //GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube3.transform.position;
                if (GameManager.Instance.BallList7.Count == 0)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-2.8f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.65f, 1);
                }
                else if (GameManager.Instance.BallList7.Count == 1)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-2.8f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.84f, 1);
                }
                else if (GameManager.Instance.BallList7.Count == 2)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-2.8f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.03f, 1);
                }
                else
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-2.8f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.22f, 1);
                }

                GameManager.Instance.BallList7.Add(GameManager.Instance.CurrentBall);

                GameManager.Instance.CurrentBall = null;
            }
        }
    }

    IEnumerator bekle()
    {
        yield return new WaitForSecondsRealtime(0.2f);
    }
}
