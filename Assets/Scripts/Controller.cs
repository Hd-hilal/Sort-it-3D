using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class Controller : MonoBehaviour
{
    public float raylength;
    public LayerMask layermask;

    public GameObject Cube;
    public GameObject Cube1;
    public GameObject Cube2;

    public List<GameObject> ballBlock;
    public List<GameObject> ballBlock1;
    public List<GameObject> ballBlock2;

    Vector3 position;
    Vector3 position1;
    Vector3 position2;

    bool ilksecim = false;
    bool ikincisecim = true;

    int ilkkaceleman;
    int ortakaceleman;
    int sonkaceleman;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, raylength, layermask))
            {
                if (!ilksecim)
                {
                    ilksecim = true;
                    if (hit.transform.gameObject == Cube)
                    {
                        var lastItem = ballBlock.LastOrDefault();
                        position = lastItem.transform.position;
                        if (transform.position.y <= 1.25f)
                        {
                            position.y++;
                            lastItem.transform.position = position;
                        }
                        ballBlock.Remove(lastItem);
                        GameManager.Instance.CurrentBall = lastItem;
                    }

                    else if (hit.transform.gameObject == Cube1)
                    {
                        var lastItem1 = ballBlock1.LastOrDefault();
                        position1 = lastItem1.transform.position;
                        if (transform.position.y <= 1.25f)
                        {
                            position1.y++;
                            lastItem1.transform.position = position1;
                        }
                        ballBlock1.Remove(lastItem1);
                        GameManager.Instance.CurrentBall = lastItem1;
                    }

                    else
                    {
                        var lastItem2 = ballBlock2.LastOrDefault();
                        position2 = lastItem2.transform.position;
                        if (transform.position.y <= 1.25f)
                        {
                            position2.y++;
                            lastItem2.transform.position = position2;
                        }
                        ballBlock2.Remove(lastItem2);
                        GameManager.Instance.CurrentBall = lastItem2;
                    }
                    ikincisecim = false;
                }

                Debug.Log("disarda");

                if (!ikincisecim)
                {
                    ilkkaceleman = ballBlock.Count;
                    ortakaceleman = ballBlock1.Count;
                    sonkaceleman = ballBlock2.Count;
                    ikincisecim = true;
                    Debug.Log("1");
                    if (hit.transform.gameObject == Cube)
                    {
                        Debug.Log("2");
                        if (ilkkaceleman == 0)
                        { 
                            ballBlock.Add(GameManager.Instance.CurrentBall);
                        }
                        else if (ilkkaceleman == 1)
                        {
                            ballBlock.Add(GameManager.Instance.CurrentBall);
                        }
                        else if (ilkkaceleman == 2)
                        {
                            ballBlock.Add(GameManager.Instance.CurrentBall);
                        }
                        else if (ilkkaceleman == 3)
                        {
                            ballBlock.Add(GameManager.Instance.CurrentBall);
                        }
                        else
                        {
                            ikincisecim = false;
                            return;
                        }
                    }


                    else if (hit.transform.gameObject == Cube1)
                    {
                        Debug.Log("3");
                        if (ortakaceleman == 0)
                        {
                            ballBlock1.Add(GameManager.Instance.CurrentBall);
                        }
                        else if (ortakaceleman == 1)
                        {
                            ballBlock1.Add(GameManager.Instance.CurrentBall);
                        }
                        else if (ortakaceleman == 2)
                        {
                            ballBlock1.Add(GameManager.Instance.CurrentBall);
                        }
                        else if (ortakaceleman == 3)
                        {
                            ballBlock1.Add(GameManager.Instance.CurrentBall);
                        }
                        else
                        {
                            ikincisecim = false;
                            return;
                        }
                    }

                    else
                    {
                        Debug.Log("4");

                        if (sonkaceleman == 0)
                        {
                            Debug.Log("5");
                            ballBlock2.Add(GameManager.Instance.CurrentBall);
                        }
                        else if (sonkaceleman == 1)
                        {
                            ballBlock2.Add(GameManager.Instance.CurrentBall);
                        }
                        else if (sonkaceleman == 2)
                        {
                            ballBlock2.Add(GameManager.Instance.CurrentBall);
                        }
                        else if (sonkaceleman == 3)
                        {

                            ballBlock2.Add(GameManager.Instance.CurrentBall);
                        }
                        else
                        {
                            ikincisecim = false;
                            return;
                        }
                    }
                }
            }
        }
    }
}
