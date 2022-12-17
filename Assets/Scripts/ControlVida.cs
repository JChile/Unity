using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVida : MonoBehaviour
{
    Slider slider; 
    Renderer[] componentes;

    private float cantVida = 4f; 
    private float invenCon;
    private float invenTie = 2.5f;
    private float parpaCon;
    private float parpaTie = 0.15f;
    private bool estadoParpa = false;
    private bool estadoInven = false;

    
    void Start()
    {
        slider = GetComponent<Slider>();
        componentes = GameObject.Find("Cohete").GetComponentsInChildren<Renderer>();        
    }

    void Update()
    {            
        if(invenCon > 0)
        {
            invenCon -= Time.deltaTime;  
            parpaCon -= Time.deltaTime;

            if(parpaCon <= 0) 
            {
                if(estadoParpa == false) 
                {
                    foreach (Renderer ren in componentes)                     
                        ren.material.EnableKeyword("_EMISSION");

                    estadoParpa = true;
                } 
                else 
                {
                    foreach (Renderer ren in componentes)         
                        ren.material.DisableKeyword("_EMISSION");
                
                    estadoParpa = false;
                }  
                parpaCon = parpaTie;  
                    
            } 
                                                                        
            if(invenCon <= 0) 
            {
                foreach (Renderer ren in componentes) 
                    ren.material.DisableKeyword("_EMISSION");

                estadoInven = false;             
            }
        }
    }

    
    public void setValue(float v) 
    {
        print("asd");
        slider.value = v;        
    }

    public float getValue() 
    {
        return slider.value;
    }

    public bool getEstado()
    {
        return estadoInven;
    }

    public void getDamage()
    {        
        if(invenCon <= 0) 
        {            
            slider.value -= cantVida;
            invenCon = invenTie;
            parpaCon = parpaTie;
            estadoInven = true;                
        } 
    }
}