using UnityEngine;
using UnityEngine.InputSystem;   // ← שורה חדשה


public class PLAYER_SCREPT : MonoBehaviour
{
    public float speed = 7f;
    Vector2 movment=Vector2.zero;
    private Rigidbody2D rb;
    public int targetScore = 1000;
    private int score = 0;
    public CoinSpawner coinSpawner;
    private bool hasWon = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        var aValue=Keyboard.current.aKey.value;
        var dValue=Keyboard.current.dKey.value;
        var wValue=Keyboard.current.wKey.value;
        var sValue=Keyboard.current.sKey.value;  
        movment = Vector2.zero;
        movment += dValue * Vector2.right;
        movment += wValue * Vector2.up;
        movment += aValue * Vector2.left;
        movment += sValue * Vector2.down;
        movment = movment.normalized;


    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position +Time.fixedDeltaTime * movment*speed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("coin"))
        {
            coin_script coin = other.GetComponent<coin_script>();
            score += coin.value;
            Debug.Log("Score: " + score);

            Destroy(other.gameObject);
            coinSpawner.CoinCollected();
            if (score >= targetScore && !hasWon)
            {
                hasWon = true;
                Debug.Log("you won");
            }
        }
       
    }

    }

