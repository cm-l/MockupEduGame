using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RunningPlayer : MonoBehaviour
{
    bool alive = true;

    public float speed = 0.5f;
    public Rigidbody rb;

    private int currentLane = 1; // 0 = lewa, 1 = środek, 2 = prawa
    private float[] lanes = { -2f, 0f, 2f };
    public float transitionSpeed = 10f;

    private void FixedUpdate() {
        if(!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 targetPosition = new Vector3(lanes[currentLane], rb.position.y, rb.position.z);
        rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, transitionSpeed * Time.fixedDeltaTime) + forwardMove);
    }

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < lanes.Length - 1)
        {
            currentLane++;
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Good"))
        {
            Destroy(other.gameObject);
            TMPController.addPoint();
            TMPController.changeEquation(EnemySpawner.tmpfirstEquationNumber, EnemySpawner.tmpresultEquationNumber);
        }
        else if (other.gameObject.CompareTag("Wrong"))
        {
            Destroy(other.gameObject);
            TMPController.substractPoint();
            TMPController.changeEquation(EnemySpawner.tmpfirstEquationNumber, EnemySpawner.tmpresultEquationNumber);
        }
    }
}
