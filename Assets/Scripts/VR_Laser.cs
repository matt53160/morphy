using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;
using UnityEditor.UI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Reamix2021
{
    public class VR_Laser : MonoBehaviour
    {
        private SteamVR_Action_Boolean m_boolean_activate;
        private Boolean state;
        public SteamVR_LaserPointer laser;
        /*private SteamVR_Action_Boolean m_BooleanAction;*/

        private void Awake()
        {
            m_boolean_activate = SteamVR_Actions.default_ActivateUI;
            m_boolean_activate[SteamVR_Input_Sources.RightHand].onStateDown += ChangeState;
            state = false;
            laser.enabled = state;
            /*m_BooleanAction = SteamVR_Actions.default_InteractUI;*/
            //laser.PointerIn += OnPointerIn;
            //laser.PointerOut += OnPointerOut;
            laser.PointerClick += OnPointerClick;
        }

        private void ChangeState(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
        {
            //Debug.Log("state => " + state);

            state = !state;
            laser.enabled = state;
            if (laser.pointer != null)
            {
                laser.pointer.SetActive(state);
                laser.holder.SetActive(state);
            }
        }

        private void OnPointerClick(object sender, PointerEventArgs e)
        {
            Debug.Log(e.target);
            if (e.target.GetComponent<Button>())
            {
                ExecuteEvents.Execute(e.target.gameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
            }
        }

        private void OnPointerOut(object sender, PointerEventArgs e)
        {
            IPointerExitHandler pointerExitHandler = e.target.GetComponent<IPointerExitHandler>();
            if (pointerExitHandler == null)
            {
                return;
            }
            Debug.Log("out => " + e);
            pointerExitHandler.OnPointerExit(new PointerEventData(EventSystem.current));
        }

        private void OnPointerIn(object sender, PointerEventArgs e)
        {

            IPointerEnterHandler pointerEnterHandler = e.target.GetComponent<IPointerEnterHandler>();
            if (pointerEnterHandler == null)
            {
                return;
            }
            Debug.Log("in => " + e);
            pointerEnterHandler.OnPointerEnter(new PointerEventData(EventSystem.current));
        }
    }

}
