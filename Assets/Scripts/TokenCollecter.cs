using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenCollecter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Black"))
        {
            GameManager.Instance.BlackToken();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("White"))
        {
            GameManager.Instance.WhiteToken();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Red"))
        {
            GameManager.Instance.RedToken();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Striker"))
        {
            GameManager.Instance.Foul();

        }
    }
}
