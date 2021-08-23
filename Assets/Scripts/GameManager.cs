using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameManager : MonoBehaviour
{
    #region SINGLETON PATTERN
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }
    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public List<GameObject> BallList1;
    public List<GameObject> BallList2;
    public List<GameObject> BallList3;
    public List<GameObject> BallList4;
    public List<GameObject> BallList5;
    public List<GameObject> BallList6;
    public List<GameObject> BallList7;

    public GameObject Tube1;
    public GameObject Tube2;
    public GameObject Tube3;
    public GameObject Tube4;
    public GameObject Tube5;
    public GameObject Tube6;
    public GameObject Tube7;

    public GameObject CurrentBall;
    public bool AnySelectedBall;

}