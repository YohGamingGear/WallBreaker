using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BolaController : MonoBehaviour
{
    public int force;
    int score;
    TextMeshProUGUI scorePad;
    Rigidbody2D rb;
    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(0, -3).normalized;
        rb.AddForce(arah * force);
        
        score = 0;
        scorePad=GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Pad")
        {
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rb.velocity.x, sudut).normalized;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(arah * force * 2);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Persegi"))
        {
            other.gameObject.SetActive(false);
            score += 10;
            TampilkanScore();
            if (score >= 100)
            {
                SceneManager.LoadScene("Menang");
            }
        }
        if (other.gameObject.CompareTag("TepiBawah"))
        {
        
            SceneManager.LoadScene("Kalah");
        }
        void TampilkanScore()
        {
            Debug.Log("Score Player: " + scorePad);
            scorePad.text = score.ToString();
        }
    }
}
