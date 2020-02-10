using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InteractionPointMenuOption : MonoBehaviour
{
    [SerializeField]
    GameObject optionsPanel;

    [SerializeField]
    InteractionPointSelection[] optionButtons;


    [SerializeField]
    Sprite closedSprite;
    [SerializeField]
    Sprite openSprite;
    [SerializeField]
    Image toggleMenuIcon;



    public void ActivateThisButton()
    {
        for (int i = 0; i < optionButtons.Length; i++)
        {
            optionButtons[i].DeactivateButton();
        }

        EventSystem.current.currentSelectedGameObject.GetComponent<InteractionPointSelection>().ActivateButton();



    }

    public void ToggleMenu()
    {
        optionsPanel.SetActive(!optionsPanel.activeInHierarchy);

        if (optionsPanel.activeInHierarchy)
        {
            toggleMenuIcon.sprite = closedSprite;
        }
        else
        {
            toggleMenuIcon.sprite = openSprite;

        }

    }
}
