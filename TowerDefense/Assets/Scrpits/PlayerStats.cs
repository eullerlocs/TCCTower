using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Energy;
    public int startEnergy = 400;

    public static int Health;
    public int startHealth = 100;

    public static int waves;

    void Start ()
    {
        Energy = startEnergy;
        Health = startHealth;

        waves = 0;
    }
}
