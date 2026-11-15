using UnityEngine;

public class moveplat : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float lenx = 10;
    public float leny = 0;
    private float endx;
    private float endy;
    private float startx;
    private float starty;
    public float speedx = .1f;
    public float speedy = 0;
    public int facingx = 1;
    public int facingy = 1;
    public Transform tf;
    public Rigidbody2D rb;
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        endx = tf.transform.position.x+lenx;
        endy = tf.transform.position.y+leny;

        startx = tf.transform.position.x - lenx;
        starty = tf.transform.position.y - leny;
    }

    void FixedUpdate()
    {
        float x = tf.position.x;
        float y = tf.position.y;
        if (x>endx)
        {
            x = endx;
            facingx = -facingx;
        }
        if (x < startx)
        {
            x = startx;
            facingx = -facingx;
        }

        if (y > endy)
        {
            y = endy;
            facingy = -facingy;
        }
        if (y < starty)
        {
            y = starty;
            facingy = -facingy;
        }
        tf.position=new Vector2 (x, y);
        rb.linearVelocity = new Vector2(facingx*speedx, facingy*speedy);


    }
}
