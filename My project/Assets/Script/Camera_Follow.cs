using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        GameController.camShake =GameObject.FindGameObjectWithTag("CameraShake").GetComponent<Camera_Shake>();
    }
    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    // void LateUpdate()
    // {
    //     if (target !=null)
    //     {
    //         if (transform.position != target.position)
    //         {
    //             Vector3 targetPos = target.position;
    //             /*線性差值*/
    //             transform.position =Vector3.Lerp(transform.position,targetPos,smoothing);
    //         }
    //     }
    // }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, 0, -10f);
    }
}
