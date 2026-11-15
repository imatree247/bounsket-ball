using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class playerstuff : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    float oggscale;
    public Vector2 sp;
    public bool stopped = true;
    public GameObject powerthingy;
    public float powerthingydampening = .5f;
    public GameObject score;
    public AudioSource music;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        oggscale = rb.gravityScale;
        stoppl();
        sp = rb.position;
    }
    public void stoppl()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.rotation=Quaternion.identity;
        rb.gravityScale = 0f;
        stopped = true;
        rb.simulated = false;
        powerthingy.SetActive(true);
        GameManager.Instance.candrag = true;
    }
    public void startpl()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = 0f;
        rb.gravityScale = oggscale;
        GameManager.Instance.candrag = false;
        rb.simulated = true;
        stopped = false;
        rb.position = sp;
        rb.linearVelocity = (powerthingy.transform.Find("orgin").gameObject.transform.position - powerthingy.transform.Find("moveableplat").gameObject.transform.position) * powerthingydampening;
        powerthingy.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (stopped)
        {
            rb.position = sp;
            transform.position = sp;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("hoopfinish"))
        {
            stopped = true;
            stoppl();
            score.SetActive(true);
            FadeOut();
            Invoke("end", 1.5f);
        }
        else if (other.gameObject.name.Contains("spike"))
        {
            rb.position = sp;
            stoppl();
        }
    }
    private void end()
    {
        SceneManager.LoadScene("start", LoadSceneMode.Single);
    }
    public void runclick()
    {
        if (stopped)
            startpl();
        else
            stoppl();
    }
    private IEnumerator FadeOut()
    {
        while(music.volume>0)
        {
            yield return null;
            float minus = Time.deltaTime;
            music.volume -= minus;
        }
    }
}

    
