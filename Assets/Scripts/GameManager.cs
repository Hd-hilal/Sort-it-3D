using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject Tube1;
    public GameObject Tube2;
    public GameObject Tube3;

    public GameObject CurrentBall;
    public bool AnySelectedBall;
}
