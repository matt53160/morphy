using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection2 : MonoBehaviour
{
    public GameObject object1;
    public GameObject morphy;
    public GameObject image;
    public ParticleSystem explosion;
    public GameObject tourne_vis;
    GameObject explo;
    public void Start()
    {
        explosion.Pause();
    }
    private void OnTriggerEnter(Collider object_)
    {

        if (object_.transform == object1.transform)
        {
            tourne_vis.SetActive(true);
            explosion.transform.position = morphy.transform.position;
            explosion.Stop();
            explosion.Play();
            morphy.SetActive(false);
            image.SetActive(false);
            Destroy(explo, 5);
            
            //explosion.SetActive(true);

        }



    }

    private void OnTriggerExit(Collider object_)
    {
        /*if (object_ == object1)
        {
            object1.SetActive(false);
        }*/


    }
}