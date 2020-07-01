using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    [SerializeField] GameObject EnemySpotLight;
   
      private bool LightOn = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(LightOn==false)
            {
                flashlight.gameObject.SetActive(true);
                EnemySpotLight.gameObject.SetActive(true);
                LightOn = true;
            }
            else if (LightOn == true)
            {
                flashlight.gameObject.SetActive(false);
                EnemySpotLight.gameObject.SetActive(false);
                LightOn = false;
            }
        }
        
    }
}
