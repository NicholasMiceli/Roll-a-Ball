using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    public Text countText;
    public Text scoreText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private int score;
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        SetCountText ();
        SetScoreText ();
        winText.text = "";
    }
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            score = score + 1;
            SetCountText ();
            SetScoreText ();
            NextLevel ();
        }
        if (other.gameObject.CompareTag("Enemy Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count - 1;
            score = score + 1;
            SetCountText ();
            SetScoreText ();
        }
    }

    void SetCountText ()    
    {
        countText.text = "Score: " + count.ToString ();
        if (count >= 20){
            winText.text = "You Win!";
        }
    }
    void SetScoreText ()
    {
        scoreText.text = "Count: " + score.ToString();
    }
    void NextLevel ()
    {
        if (count == 12)
        {
         transform.position = new Vector3 (40,0,0);
        }
    }
}