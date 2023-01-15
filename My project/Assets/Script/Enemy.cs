using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color orginal_Color;
    public int damge, LifePoint;

    public float flashtime;
    // Start is called before the first frame update
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        orginal_Color = sr.color;
    }

    // Update is called once per frame
    public void Update()
    {
        if (LifePoint <= 0)
        {
            Destroy(gameObject);
        }
    }

    /*Take Damage*/
    public void TakeDamage(int damge)
    {
        LifePoint -= damge;
        FlashColor(flashtime);
    }


    //flash how long for input peremeter
    void FlashColor(float time)
    {
        sr.color = Color.red;
        Invoke("Reset_Color", time);
    }

    void Reset_Color()
    {
        sr.color = orginal_Color;
    }

    
}
