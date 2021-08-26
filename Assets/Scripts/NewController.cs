using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewController : MonoBehaviour
{
    public Bitir[] item;
    public GameObject button;
    public Text level;
    int scene,artis;

    private void Start()
    {
        button.SetActive(false);
        scene = SceneManager.GetActiveScene().buildIndex;
        scene++;
        artis = SceneManager.GetActiveScene().buildIndex;
        artis++;
        if (artis >= 5)
        {
            level.text = ("Level " + artis);
            artis++;
        }
        else
        {
            level.text = ("Level " + artis);
        }
        PlayerPrefs.SetInt("Scene", scene);
        Debug.Log(PlayerPrefs.GetInt("Scene"));

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
                        else if (hit.transform.name == "Tube4") SelectBall("BallList4");
                        else if (hit.transform.name == "Tube5") SelectBall("BallList5");
                        else if (hit.transform.name == "Tube6") SelectBall("BallList6");
                        else if (hit.transform.name == "Tube7") SelectBall("BallList7");
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
                        else if (hit.transform.name == "Tube4") MoveToTubeBall("BallList4");
                        else if (hit.transform.name == "Tube5") MoveToTubeBall("BallList5");
                        else if (hit.transform.name == "Tube6") MoveToTubeBall("BallList6");
                        else if (hit.transform.name == "Tube7") MoveToTubeBall("BallList7");
                    }

                    //Havada Herhangi bir top seçilmiþse kontrolü yap
                    CheckBalls();
                }

            }
        }
    }

    void CheckBalls()
    {
        //Doðru Yapýlmýþ tüp sayýsý
        int correctTubeCount = 0;

        //Seçilen tüpte ilk topun tagý(Tüpte hepsi ayný renk olduðundan diðer tüpler ilkiyle ayný tagta olmalý)
        string firstBallTagInListed = null;

        for (int i = 0; i < item.Length; i++) //Tüplerde Dönüyor
        {
            if (item[i].listed.Count != 0) //Secilen tüpün içinde top var mý
            {
                if (item[i].listed.Count == 4) // Tüp 4 topla tamamen dolu mu
                {
                    for (int j = 0; j < item[i].listed.Count; j++) // Seçilen tüpteki toplara dönüyor
                    {
                        if (j == 0) //Ýlk topa mý bakýyoruz
                        {
                            firstBallTagInListed = item[i].listed[j].tag; // ilk topun tagýný tut

                        }
                        else 
                        {
                            if (item[i].listed[j].tag != firstBallTagInListed) break; //Diðer toplarýn tagý ilk topla ayný deðilse fonksiyondan çýk(break ile for yarýda kesilebilir)

                        }

                    }

                    correctTubeCount++; // Tüm toplar ayný renkse doðru tüp sayýsýný artýr.
                }
                else
                {
                    break; // Tüpte 4 tane top yoksa fonksiyondan çýk.
                }

            }
            else
            {
                correctTubeCount++; // Tüp boþsa doðru tüp kabul et
            }

        }

        if (correctTubeCount == item.Length) // Tüm döngü bittiðinde doðru tüp sayýsý toplam tüp sayýsýna eþit mi 
        {
            artis++;
            Debug.Log("WIN");
            button.SetActive(true);
        }
    }

    public void degistir(int sahneid)
    {
        SceneManager.LoadScene(sahneid);
    }

    //private void cont()
    //{
    // int sayac = 0;
    //eleman = item.Length;
    //if (eleman == 5)
    //{
    //    if (clicked)
    //    {
    //for{ i = 1; i < 5 ;i++ }
    //   {
    //            for (j = 1; j < 4; j++)
    //            {
    //                ball = item[0].listed[0];
    //                ball1 = item[1].listed[j];

    //            print(item[2].listed[0]);
    //                if (ball.tag == item[0].listed[j].tag && ball1.tag == item[1].listed[j].tag  && ball2.tag == item[2].listed[j].tag && ball3.tag == item[3].listed[j].tag && ball4.tag == item[4].listed[j].tag)
    //                {
    //                    sayac++;
    //                    print("sükür");
    //                    print(sayac);
    //                }
    //                else
    //                {
    //                    print("dogru degil");
    //                     clicked = false;
    //                    sayac = 0;
    //                }
    //                print("tamam");
    //            }
    //        clicked = true;
    //    }
    //}
    //}



    //    if (eleman == 5)
    //    {
    //        for (j = 1; j < 4; j++)
    //        {
    //            if (item[0].listed[0].tag == item[0].listed[j].tag)
    //            {
    //                print("girdi");
    //                sayac++;
    //            }
    //            else
    //            {
    //                sayac = 0;
    //                j = 1;
    //            }

    //            if (sayac == 3)
    //            {
    //                print("oldu");
    //            }
    //            else
    //            {
    //                print("olmadi");
    //            }
    //            print(sayac);
    //        }
    //        print("bitti");
    //    }
    //}

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
                item[0].listed = GameManager.Instance.BallList1;
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
                item[1].listed = GameManager.Instance.BallList2;
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
                item[2].listed = GameManager.Instance.BallList3;
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
                item[3].listed = GameManager.Instance.BallList4;
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
                item[4].listed = GameManager.Instance.BallList5;
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
                item[5].listed = GameManager.Instance.BallList6;
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
                item[6].listed = GameManager.Instance.BallList7;
                GameManager.Instance.AnySelectedBall = true;
            }
        }
        MoveToUpBall();
    }

    void MoveToUpBall()
    {
        //Yukarý hareket
        //GameManager.Instance.CurrentBall.transform.Translate(Vector3.up * 1f);
        GameManager.Instance.CurrentBall.transform.DOMoveY(2.5f, 0.2f);
    }

    //TOP GÖTÜRÜLÜYOR
    void MoveToTubeBall(string listName)
    {
        if (listName == "BallList1") // Seçilen tüpe göre hangi liste
        {
            if (GameManager.Instance.BallList1.Count < 4) // Seçilen tüp dolu mu 
            {
                GameManager.Instance.AnySelectedBall = false; // Artýk seçilen havada top yok  

                //GameManager.Instance.CurrentBall.transform.position = GameManager.Instance.Tube1.transform.position;
                if (GameManager.Instance.BallList1.Count == 0)
                {
                    GameManager.Instance.CurrentBall.transform.DOMoveX(1.4f, 0.2f);
                    StartCoroutine(bekle());
                    GameManager.Instance.CurrentBall.transform.DOMoveY(0.7f, 1);
                }
                else if (GameManager.Instance.BallList1.Count == 1)
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
                GameManager.Instance.BallList1.Add(GameManager.Instance.CurrentBall); // Seçilen top yeni tüpün listesine eklendi
                item[0].listed = GameManager.Instance.BallList1;
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
                item[1].listed = GameManager.Instance.BallList2;
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
                item[2].listed = GameManager.Instance.BallList3;
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
                item[3].listed = GameManager.Instance.BallList4;
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
                item[4].listed = GameManager.Instance.BallList5;
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
                item[5].listed = GameManager.Instance.BallList6;
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
                item[6].listed = GameManager.Instance.BallList7;
                GameManager.Instance.CurrentBall = null;
            }
        }
    }

    IEnumerator bekle()
    {
        yield return new WaitForSecondsRealtime(0.2f);
    }

}
