using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsView : MonoBehaviour
{
    public Button switchButton;
    public GameObject panelToDeactivate;
    public GameObject panelToActivate;

    private void Start()
    {
        if (switchButton != null)
        {
            switchButton.onClick.AddListener(SwitchPanel);
        }
    }

    private void SwitchPanel()
    {
        if (panelToDeactivate != null)
        {
            panelToDeactivate.SetActive(false);
        }

        if (panelToActivate != null)
        {
            panelToActivate.SetActive(true);
        }
    }
}
