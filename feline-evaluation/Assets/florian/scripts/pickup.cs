using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickup : MonoBehaviour
{
    public int points = 0;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = points;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            points++;
        }
    }
}
