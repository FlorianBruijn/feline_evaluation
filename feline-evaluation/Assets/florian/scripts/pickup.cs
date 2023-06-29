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
    public int nextScene;
    public TMPro.TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check point amount
        if(points < 5)
        {
            text.text = "kil all enemys";
        }
        slider.value = points;
        if (points == 5)
        {
            text.text = "go to ship";
            can_return = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //pickup item
        if(other.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            points++;
        }
        //enter schip
        if(other.tag == "ship" && can_return)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
