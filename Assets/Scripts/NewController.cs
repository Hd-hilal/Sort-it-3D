using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NewController : MonoBehaviour
{
    int i = 0,j=0;
    string deneme;
    string a1,b1,c1,d1;
    [HideInInspector]public int tubeNumber =6;
    public GameObject[,] objectArray;
    public GameObject dizi,dizi1,dizi2;
    public GameObject eleman;
    bool olmadi=true;


    private void FixedUpdate()
    {
        objectArray = new GameObject[tubeNumber, 4];

        for(i=0 ; i<4 ; i++)
        {
            objectArray[0, i] = GameManager.Instance.BallList1[i];
            objectArray[1, i] = GameManager.Instance.BallList2[i];
            objectArray[2, i] = GameManager.Instance.BallList3[i];
        }
      /*
        for (i = 0; i < 4; i++)
        {

        }
        for (i = 0; i < 4; i++)
        {
        }
      */
      /*
        for (i = 0; i < 4; i++)
        {
            objectArray[3, i] = GameManager.Instance.BallList4[i];
        }
        for (i = 0; i < 4; i++)
        {
            objectArray[4, i] = GameManager.Instance.BallList5[i];
        }
        for (i = 0; i < 5; i++)
        {
            objectArray[5, i] = GameManager.Instance.BallList6[i];
        }
        for (i = 0; i < 4; i++)
        {
            objectArray[6, i] = GameManager.Instance.BallList7[i];
        }
        */
    }


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
        //if (i < 4)
        // {
        //   deneme = GameManager.Instance.BallList1[i];
        //   i++;
        //   print(deneme);
        //}
        ol();
    }
    void ol()
    {
        //a1 = GameManager.Instance.BallList1[0].tag;
        //b1 = GameManager.Instance.BallList1[1].tag;
        //c1 = GameManager.Instance.BallList1[2].tag;
        //d1 = GameManager.Instance.BallList1[3].tag;



        //if (a1 == b1 && b1 == c1 && c1 == d1)
        //{
          //  print("oldu");
        //}
        if(olmadi)
        {

            //for (i=0;i<7;i++)
            //{
            // j = 0;
            i = 0;
                eleman = objectArray[i, 0];
                dizi = objectArray[i, j+1];
                dizi1 = objectArray[i, j + 2];
                dizi2 = objectArray[i, j + 3];

            var aeleman = objectArray[i + 1, 0];
            var adizi = objectArray[i + 1, j + 1];
            var adizi1 = objectArray[i + 1, j + 2];
            var adizi2 = objectArray[i + 1, j + 3];

            var beleman = objectArray[i + 2, 0];
            var bdizi = objectArray[i + 2, j + 1];
            var bdizi1 = objectArray[i + 2, j + 2];
            var bdizi2 = objectArray[i + 2, j + 3];





            if (eleman == dizi && dizi == dizi1 && dizi1 == dizi2) { print("1 OK!"); }
                if (aeleman == adizi && adizi == adizi1 && adizi1 == adizi2) { print("A OK!"); }
                if (beleman == bdizi && bdizi == bdizi1 && bdizi1 == bdizi2) { print("B OK!"); }



            /*
            if (eleman==dizi && dizi == dizi1 && dizi1 == dizi2)
            {

                print("do�ru");   

            }
            else
            {
                print("yanlis");
                olmadi = false;
                break;
            }
            */
            //}

            olmadi = true;
            i = 0;
        }

        //if (i < 0)
        //{
        //    material temp = gamemanager.�nstance.balllist1[0].gameobject.getcomponent<meshrenderer>().material;
        //    if (i == 0)
        //    {
        //        mat = temp;
        //        print(mat);
        //    }
        //    if (i == 1)
        //    {
        //        mat1 = temp;
        //        print(mat1);
        //    }
        //    if (i == 2)
        //    {
        //        mat2 = temp;
        //        print(mat2);
        //    }
        //    if (i == 3)
        //    {
        //        mat3 = temp;
        //        print(mat3);
        //    }


        //    if (mat == mat1 && mat1 == mat2 && mat2 == mat3)
        //    {
        //        print("oldu");
        //    }
        //    else
        //    {
        //        print("olmadi");
        //    }

        //}
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
        GameManager.Instance.CurrentBall.transform.DOMoveY(2.5f, 0.2f);
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
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.7f, 1);
                }
                else if(GameManager.Instance.BallList1.Count == 1) 
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1f, 1);
                }
                else if (GameManager.Instance.BallList1.Count == 2)
                { 
                    GameManager.Instance.CurrentBall.transform.DOMoveX(1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.3f, 1);
                }
                else
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.6f, 1);
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
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.7f, 1);
                }
                else if (GameManager.Instance.BallList2.Count == 1) 
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1f, 1);
                }
                else if (GameManager.Instance.BallList2.Count == 2) 
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.3f, 1);
                }
                else
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.6f, 1);
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
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.7f, 1);
                }
                else if (GameManager.Instance.BallList3.Count == 1) 
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1f, 1);
                }
                else if (GameManager.Instance.BallList3.Count == 2) 
                {      
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.3f, 1);
                }
                else 
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(0, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.6f, 1);
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
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.7f, 1);
                }
                else if (GameManager.Instance.BallList4.Count == 1)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1f, 1);
                }
                else if (GameManager.Instance.BallList4.Count == 2)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.3f, 1);
                }
                else
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-0.7f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.6f, 1);
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
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.7f, 1);
                }
                else if (GameManager.Instance.BallList5.Count == 1)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1f, 1);
                }
                else if (GameManager.Instance.BallList5.Count == 2)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.3f, 1);
                }
                else
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.6f, 1);
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
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.7f, 1);
                }
                else if (GameManager.Instance.BallList6.Count == 1)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-2.1f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1f, 1);
                }
                else if (GameManager.Instance.BallList6.Count == 2)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-2.1f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.3f, 1);
                }
                else
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-2.1f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.6f, 1);
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
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.7f, 1);
                }
                else if (GameManager.Instance.BallList7.Count == 1)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-2.8f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1f, 1);
                }
                else if (GameManager.Instance.BallList7.Count == 2)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-2.8f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.3f, 1);
                }
                else
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(-2.8f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(1.6f, 1);
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
