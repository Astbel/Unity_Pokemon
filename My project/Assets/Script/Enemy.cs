using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int damge, LifePoint;
    // Start is called before the first frame update
    public void Start()
    {

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
    }

}
