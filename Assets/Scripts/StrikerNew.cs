using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikerNew : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    CircleCollider2D coll;
    Transform selftrans;
    Vector2 startpos;
    public Slider myslider;
    Vector2 direction;
    Vector3 mousepos;
    Vector3 mouspos2;
    Transform arrowtransorm;
    public GameObject arrowdir;
    public Transform strikerBg;
    public LineRenderer line;
    bool hasStriked = false;
    bool positionset = false;
    public GameObject bord;
    bool no = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        selftrans = transform;
        startpos = transform.position;
        arrowtransorm = arrowdir.transform;
        coll = GetComponent<CircleCollider2D>();
    }
    public void shootstriker()
    {
        float x = 0;
        if (positionset && rb.velocity.magnitude == 0)
        {
            x = Vector2.Distance(transform.position, mousepos);
        }
        direction = (Vector2)(mouspos2 - transform.position);
        direction.Normalize();
        rb.AddForce(direction * x * 300);
        hasStriked = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Red")|| collision.gameObject.tag == ("Black")||collision.gameObject.tag == ("White"))
        {
            no = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Red") || collision.gameObject.tag == ("Black") || collision.gameObject.tag == ("White"))
        {
            no = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Red") || collision.gameObject.tag == ("Black") || collision.gameObject.tag == ("White"))
        {
            no = false;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Red") || collision.gameObject.tag == ("Black") || collision.gameObject.tag == ("White"))
        {
            no = true;
        }
    }
  

    // Update is called once per frame
    void Update()
    {
       
        strikerBg.localScale = Vector3.zero;
        arrowdir.SetActive(false);

        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 inverseMouPos = new Vector3(Screen.width - Input.mousePosition.x, Screen.height - Input.mousePosition.y, Input.mousePosition.z);
        mouspos2 = Camera.main.ScreenToWorldPoint(inverseMouPos);
        mouspos2.y = mouspos2.y - 3;

        if (selftrans.position.x != 0)
        {
            mouspos2.x = mouspos2.x + (selftrans.position.x * 2);
        }
        if (mouspos2.y > 0.547f)
        {
            mouspos2.y = 0.547f;
        }
        if (mouspos2.y < -2.85f)
        {
            mouspos2.y = -2.85f;
        }
        if (mouspos2.x < -2.45f)
        {
            mouspos2.y = -2.45f;
        }
        if (mouspos2.x > 2.61f)
        {
            mouspos2.x = 2.61f;
        }
        if (!hasStriked && !positionset)
        {
            coll.isTrigger = true;
            selftrans.position = new Vector2(myslider.value, startpos.y);
        }
        if (Input.GetMouseButtonUp(0) && rb.velocity.magnitude == 0 && positionset)
        {
            shootstriker();
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (Input.GetMouseButtonDown(0) && no)
            {
                if (!positionset)
                {
                    positionset = true;
                    coll.isTrigger = false;
                }
            }

            if(Input.GetMouseButtonDown(0) && !no)
            {
                Debug.Log("you cant strike here ");
            }
        }
        if (positionset && rb.velocity.magnitude == 0)
        {
            arrowdir.SetActive(true);
            float ScaleValue = Vector2.Distance(transform.position, mouspos2);
            strikerBg.localScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);
            float angle = AngleBetweenTwoPoints(arrowtransorm.position, mouspos2);
            arrowtransorm.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90));
        }
        if (rb.velocity.magnitude < 0.1f && rb.velocity.magnitude != 0)
        {
            StartCoroutine(WaitForReset());
           
        }
    }
    public void strikerreset()
    {
        rb.velocity = Vector2.zero;
        hasStriked = false;
        positionset = false;
       
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    IEnumerator WaitForReset()
    {
        yield return new WaitForSeconds(1.5f);
        strikerreset();
    }
}
