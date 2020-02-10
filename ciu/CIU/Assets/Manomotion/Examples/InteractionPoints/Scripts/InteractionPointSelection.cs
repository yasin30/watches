using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractionPointSelection : MonoBehaviour
{

    [SerializeField]
    Image inner;
    [SerializeField]
    Image icon;


    public void DeactivateButton()
    {
        inner.enabled = false;
        icon.color = Color.white;
    }

    public void ActivateButton()
    {
        inner.enabled = true;
        icon.color = new Color(0.4f, 0, 1, 1);
    }

}
