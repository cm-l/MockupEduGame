using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject heartImage;
    public GameObject[] hearts;
    [SerializeField] private AudioClip hurtSound;
    public int hp { get; private set; }
    
    void Start()
    {
        hp = 2; // counting from 0
        hearts = new GameObject[hp + 1];

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = Instantiate(heartImage, GameObject.FindGameObjectWithTag("Heart").transform) as GameObject;
        }
    }

    public void TakeDamage()
    {
        SoundSystemSingleton.Instance.PlaySfxSound(hurtSound);
        hearts[hp].GetComponent<Heart>().SetEmpty(true);
        hp -= 1;
    }
}