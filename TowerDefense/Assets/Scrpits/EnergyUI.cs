using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{
    public Text energyText;

    // Update is called once per frame
    void Update()
    {
        energyText.text = "Energy: " + PlayerStats.Energy.ToString();
    }
}
