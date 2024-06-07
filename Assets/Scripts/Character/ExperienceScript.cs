using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceScript : MonoBehaviour
{
    public Image expImage;
    public float currentExperience, expTNL;

    public static ExperienceScript instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        expImage.fillAmount = currentExperience / expTNL;
    }

    public void expModifier(float experience)
    {
        currentExperience += experience;

        if(currentExperience>=expTNL)
        {
            expTNL = expTNL * 1.2f;
            currentExperience = 0;
            print("lvl up");
        }
    }
}
