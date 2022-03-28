using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

namespace Reamix2021
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(UIElement))]
    [RequireComponent(typeof(Interactable))]
    public class VR_Button : MonoBehaviour
    {
        private BoxCollider boxCollider;
        private RectTransform rectTransform;

        private void OnEnable()
        {
            if (boxCollider == null)
            {
                boxCollider = gameObject.AddComponent<BoxCollider>();
            }
            boxCollider.isTrigger = true;

            if (GetComponent<Toggle>() == null)
            {
                boxCollider.size = GetComponent<RectTransform>().sizeDelta;
            }
        }

    }
}

