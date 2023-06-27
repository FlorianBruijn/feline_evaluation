using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pickup : MonoBehaviour
{
    public int points = 0;
    public Slider slider;
    public bool can_return = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = points;
        if (points == 5)
        {
            can_return = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            points++;
        }
        if(other.tag == "ship" && can_return)
        {
            SceneManager.LoadScene(1);
        }
    }
}
