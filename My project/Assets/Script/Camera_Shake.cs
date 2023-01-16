using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Shake : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator canAnim;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*Shake camera*/
    public void Shake()
    {
        canAnim.SetTrigger("Shake");
    }
}

