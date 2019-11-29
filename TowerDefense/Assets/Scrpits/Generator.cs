using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int generationAmount = 50;
    public int generationRate = 10;
    private float countdown = 0f;
    
    void Start()
    {
        countdown = generationRate;
    }
    void Update()
    {
        if (countdown <= 0f)
        {
            GenerateEnergy();
        }
        
        
        countdown -= Time.deltaTime;
        
    }
    public void GenerateEnergy()
    {
        PlayerStats.Energy += generationAmount;
        countdown = generationRate;
    }
   
}
