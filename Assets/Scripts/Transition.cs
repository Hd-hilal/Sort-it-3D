using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Transition : MonoBehaviour
{
    public Text level;
    int scene;
    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        print(scene);
        level.text = ("Level" + scene);
    }
    public void degistir(int sahneid)
    {
        SceneManager.LoadScene(sahneid);
    }
}
