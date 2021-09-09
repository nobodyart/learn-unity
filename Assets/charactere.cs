using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactere : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Vector2 dir;
    Animator anim;
    public GameObject quete;
    bool chestOk = false;// quete terminer??
    public BoxCollider2D colliderPnj;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
        SetParam();
    }

    void SetParam()
    {
        if (dir.x == 0 && dir.y == 0)
            anim.SetInteger("New Int", 0);

       else if (dir.y < 0 )//bas
            anim.SetInteger("New Int", 1);

       else if (dir.y > 0)//haut
            anim.SetInteger("New Int", 3);
       
       else if (dir.x > 0)//droite
        {
            anim.SetInteger("New Int", 2);
            GetComponent<SpriteRenderer>().flipX = true;
        }

       else if (dir.x < 0)//gauche
        {
            anim.SetInteger("New Int", 2);
            GetComponent<SpriteRenderer>().flipX = false;
        }


}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "quete1")
        {
            Destroy(collision.gameObject.GetComponent<CircleCollider2D>());
            quete.SetActive(true);
            StartCoroutine("HideQuest");
        }
        if (collision.gameObject.name == "chest")
        {
            Destroy(collision.gameObject);
            chestOk = true;//quete fini
            Destroy(colliderPnj);
            
        }
    }
   IEnumerator HideQuest()
    {
        yield return new WaitForSeconds(3);
        quete.SetActive(false);
    }
}
