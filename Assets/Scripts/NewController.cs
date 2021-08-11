using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        GameManager.Instance.CurrentBall.transform.Translate(Vector3.up * 1f);
    }

    //TOP G�T�R�L�YOR
    void MoveToTubeBall(string listName)
    {
        if (listName == "BallList1") // Se�ilen t�pe g�re hangi liste
        {
            if (GameManager.Instance.BallList1.Count < 4) // Se�ilen t�p dolu mu 
            {
                GameManager.Instance.AnySelectedBall = false; // Art�k se�ilen havada top yok 
                GameManager.Instance.BallList1.Add(GameManager.Instance.CurrentBall); // Se�ilen top yeni t�p�n listesine eklendi 

                // BURAYI D�REKT YEN� T�P�N KONUMUNA SETLED�M SEN HANG� KONUMUNA G�DECE��N� YAPARSIN
                GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube1.transform.position; 

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
                GameManager.Instance.BallList2.Add(GameManager.Instance.CurrentBall);

                GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube2.transform.position;
                GameManager.Instance.CurrentBall = null;
            }

        }
        else if (listName == "BallList3")
        {
            if (GameManager.Instance.BallList3.Count < 4)
            {
                GameManager.Instance.AnySelectedBall = false;
                GameManager.Instance.BallList3.Add(GameManager.Instance.CurrentBall);

                GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube3.transform.position;
                GameManager.Instance.CurrentBall = null;
            }

        }
    }
}
