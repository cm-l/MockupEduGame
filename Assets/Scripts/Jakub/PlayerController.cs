using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject heartImage;
    public GameObject[] hearts;
    public int hp = 2; // counting from 0
    
    void Start()
    {
        hearts = new GameObject[hp + 1];

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = Instantiate(heartImage, GameObject.FindGameObjectWithTag("Heart").transform) as GameObject;
        }
    }

    public void TakeDamage()
    {   
        hearts[hp].GetComponent<Heart>().SetEmpty(true);
        hp -= 1;

        if (hp < 0)
            SceneManager.LoadScene(1);
    }
}