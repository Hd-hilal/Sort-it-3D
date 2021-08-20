using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ThreeController : MonoBehaviour
{
    public GameObject[,] array;
    public GameObject dizi, dizi1, dizi2, dizi3, adizi, adizi1, adizi2, adizi3, bdizi, bdizi1, bdizi2, bdizi3;
    public GameObject[] eleman;
    int i;

    private void FixedUpdate()
    {
        array = new GameObject[3,4];
        //for(i=0;i<4;i++)
        //{
            array[0, 0] = GameManager.Instance.BallList1[0];
            array[0, 1] = GameManager.Instance.BallList1[1];
            array[0, 2] = GameManager.Instance.BallList1[2];
            array[0, 3] = GameManager.Instance.BallList1[3];

        array[1, 0] = GameManager.Instance.BallList2[0];
        array[1, 1] = GameManager.Instance.BallList2[1];
        array[1, 2] = GameManager.Instance.BallList2[2];
        array[1, 3] = GameManager.Instance.BallList2[3];

        array[2, 0] = GameManager.Instance.BallList3[0];
        array[2, 1] = GameManager.Instance.BallList3[1];
        array[2, 2] = GameManager.Instance.BallList3[2];
        array[2, 3] = GameManager.Instance.BallList3[3];
    
        //}
    }
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
        ol();
    }

    private void ol()
    {
        print(array[0, 0]);
        print(array[0, 1]);
        print(array[0, 2]);
        print(array[0, 3]);

        if (array[0, 0].tag == array[0, 1].tag && array[0, 1].tag == array[0, 2].tag && array[0, 2].tag == array[0, 3].tag)
        {
            print("A OK!");
        }
        if (array[1, 0].tag == array[1, 1].tag && array[1, 1].tag == array[1, 2].tag && array[1, 2].tag == array[1, 3].tag)
        {
            print("B OK!");
        }
        if (array[2, 0].tag == array[2, 1].tag && array[2, 1].tag == array[2, 2].tag && array[2, 2].tag == array[2, 3].tag)
        {
            print("C OK!");
        }


        //dizi = array[0, 0];
        //dizi1 = array[0, 1];
        //dizi2 = array[0, 2];
        //dizi3 = array[0, 3];

        //adizi = array[1, 0];
        //adizi1 = array[1, 1];
        //adizi2 = array[1, 2];
        //adizi3 = array[1, 3];

        //bdizi = array[2, 0];
        //bdizi1 = array[2, 1];
        //bdizi2 = array[2, 2];
        //bdizi3 = array[2, 3];

        //print(array[0, 0]);
        //print(array[0, 1]);
        //print(array[0, 2]);
        //print(array[0, 3]);

        //if (dizi == dizi1 && dizi1 == dizi2 && dizi2 == dizi3) {
        //    print("A OK!");
        //    if (adizi == adizi1 && adizi1 == adizi2 && adizi2 == adizi3) {
        //        print("B OK!");
        //        if (bdizi == bdizi1 && bdizi1 == bdizi2 && bdizi2 == bdizi3) {
        //            print("C OK!"); }
        //    }
        //}
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
        //GameManager.Instance.CurrentBall.transform.Translate(Vector3.up * 1f);
        GameManager.Instance.CurrentBall.transform.DOMoveY(1.70f, 0.2f);
    }

    //TOP GÖTÜRÜLÜYOR
    void MoveToTubeBall(string listName)
    {
        //DÝÐER LÝSTELER ÝÇÝN AYNISI
        if (listName == "BallList1")
        {
            if (GameManager.Instance.BallList1.Count < 4)
            {
                GameManager.Instance.AnySelectedBall = false;

                //GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube2.transform.position;
                if (GameManager.Instance.BallList1.Count == 0)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.65f, 1);
                }
                else if (GameManager.Instance.BallList1.Count == 1)
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
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.65f, 1);
                }
                else if (GameManager.Instance.BallList3.Count == 1)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.84f, 1);
                }
                else if (GameManager.Instance.BallList3.Count == 2)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.03f, 1);
                }
                else
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0f, 0.2f);
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
