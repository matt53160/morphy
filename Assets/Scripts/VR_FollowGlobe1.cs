using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Reamix2021
{
    public class VR_FollowGlobe1 : MonoBehaviour
    {

        public Transform globe;
        private SteamVR_Action_Boolean m_BooleanAction;
        private BoxCollider m_ButtonCollider;
        private BoxCollider m_MovingPartCollider;

        private void Awake()
        {
            m_ButtonCollider = transform.GetComponent<BoxCollider>();
            m_MovingPartCollider = transform.GetChild(0).GetComponent<BoxCollider>();

            m_ButtonCollider.enabled = false;
            m_MovingPartCollider.enabled = false;

            m_BooleanAction = SteamVR_Actions.default_GrabGrip;
            m_BooleanAction[SteamVR_Input_Sources.Any].onStateDown += UpTest;
            m_BooleanAction[SteamVR_Input_Sources.Any].onStateUp += DownTest;
        }

        private void Start()
        {
            /* Debug.Log("Globe pos l: " + globe.localPosition);
             Debug.Log("Globe pos : " + globe.position);
             Debug.Log("Transform l : " + transform.localPosition);
             Debug.Log("Transform : " + transform.position);


             float angle = globe.eulerAngles.y * Mathf.Deg2Rad;
             float x = Mathf.Cos(angle) / 4;
             float z = Mathf.Cos(angle) / 4;
             double dist = Math.Sqrt(x * x + z * z);

             float x_button = transform.position.x - globe.position.x;
             float z_button = transform.position.z - globe.position.z;
             Debug.Log("x b " + x_button);
             Debug.Log("z b " + z_button);
             double angle_button = Math.Acos(transform.position.z / transform.position.x);
             Debug.Log("angle B " + angle_button * Mathf.Rad2Deg);
             double dist_button = Math.Sqrt(x_button * x_button + z_button * z_button);

             Debug.Log("d g" + dist);
             Debug.Log("d button " + dist_button);*/
        }

        private void UpTest(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            Debug.Log("Grab");
            m_ButtonCollider.enabled = true;
            m_MovingPartCollider.enabled = true;
        }

        private void DownTest(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            Debug.Log("Ungrab");
            m_ButtonCollider.enabled = false;
            m_MovingPartCollider.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            float angle = globe.eulerAngles.y * Mathf.Deg2Rad + 90;
            float h = transform.position.y - globe.position.y;
            float rayon = 0.25f;
            float r = Mathf.Sqrt(h * h + rayon * rayon) + 0.25f;
            float x = (Mathf.Sin(angle) / 4) * r;
            float z = (Mathf.Cos(angle) / 4) * r;
            //Vector3 size = globe.GetComponent<MeshRenderer>().bounds.size;
            //Debug.Log("Angle " + angle);
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                globe.eulerAngles.y + 90,
                transform.eulerAngles.z);
            transform.position = new Vector3(
                x,
                transform.position.y,
                z);
        }

    }
}

