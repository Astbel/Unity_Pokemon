using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float time,Starttime;
    public int damge;
    private Animator anim;
    private PolygonCollider2D coli2D;
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        coli2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            anim.SetTrigger("Attack");
            StartCoroutine(StartAttack());
        }
    }
     IEnumerator StartAttack()
     {
         yield return new WaitForSeconds(Starttime);
         coli2D.enabled = true;
         StartCoroutine(disableHitBox());
     }
    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        coli2D.enabled = false;
    }
}
