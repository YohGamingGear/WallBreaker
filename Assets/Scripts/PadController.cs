using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadController : MonoBehaviour
{
    public float kecepatan;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float gerakHorizontal = Input.GetAxis("Horizontal");
        Vector2 gerakan = new Vector2(gerakHorizontal * kecepatan, rb.velocity.y);
        rb.velocity = gerakan;
    }
}
