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

                // daha önce seçilmiþ bir top var mý
                if (GameManager.Instance.AnySelectedBall == false)
                {
                    //Tube tagý olan bir objeye týklandý mý?
                    if (hit.transform.tag == "Tube")
                    {
                        // Seçilen tüpün ismine göre hangi listeden top seçilecek? 
                        if (hit.transform.name == "Tube1") SelectBall("BallList1");
                        else if (hit.transform.name == "Tube2") SelectBall("BallList2");
                        else if (hit.transform.name == "Tube3") SelectBall("BallList3");
                    }
                }
                // daha önce seçilmiþ bir top varsa 
                else
                {
                    //Tube tagý olan bir objeye týklandý mý?
                    if (hit.transform.tag == "Tube")
                    {
                        // Seçilen tüpün ismine göre hangi tüpe top götürülecek?

                        if (hit.transform.name == "Tube1") MoveToTubeBall("BallList1");
                        else if (hit.transform.name == "Tube2") MoveToTubeBall("BallList2");
                        else if (hit.transform.name == "Tube3") MoveToTubeBall("BallList3");
                    }
                }

            }
        }
    }

    //TOP SEÇÝLÝYOR
    void SelectBall(string listName)
    {
        if (listName == "BallList1") // eðer seçilen birinci listeyse 
        {
            if (GameManager.Instance.BallList1.Count > 0) // Liste boþ deðilse 
            {
                int lastBallIndex = GameManager.Instance.BallList1.Count - 1; // son elemanýn indexi 
                GameManager.Instance.CurrentBall = GameManager.Instance.BallList1[lastBallIndex]; // seçilen(current) deðiþkene son topu ekleme 

                GameManager.Instance.BallList1.RemoveAt(lastBallIndex); // tüpten topu silme 
                GameManager.Instance.AnySelectedBall = true; // þu an top seçildiðini true yapma
            }

        }

        //DÝÐER TÜPLERDEN SEÇÝLENLER ÝÇÝN AYNI ÝÞLEMLER YAPILIYOR
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
        //Yukarý hareket
        GameManager.Instance.CurrentBall.transform.Translate(Vector3.up * 1f);
    }

    //TOP GÖTÜRÜLÜYOR
    void MoveToTubeBall(string listName)
    {
        if (listName == "BallList1") // Seçilen tüpe göre hangi liste
        {
            if (GameManager.Instance.BallList1.Count < 4) // Seçilen tüp dolu mu 
            {
                GameManager.Instance.AnySelectedBall = false; // Artýk seçilen havada top yok 
                GameManager.Instance.BallList1.Add(GameManager.Instance.CurrentBall); // Seçilen top yeni tüpün listesine eklendi 

                // BURAYI DÝREKT YENÝ TÜPÜN KONUMUNA SETLEDÝM SEN HANGÝ KONUMUNA GÝDECEÐÝNÝ YAPARSIN
                GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube1.transform.position; 

                //CurrentBall deðiþkeni temizleniyor
                GameManager.Instance.CurrentBall = null;


            }

        }

        //DÝÐER LÝSTELER ÝÇÝN AYNISI
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
