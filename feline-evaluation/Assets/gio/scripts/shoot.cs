using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject prefab;
    public float delay;
    public void createProjectile()
    {

    }
    // Start is called before the first frame update

    public KeyCode shootKey = KeyCode.LeftControl;
    public void CallShot()
    {
        StartCoroutine(AwaitDelay(delay));
    }
    private IEnumerator AwaitDelay(float time)
    {
        yield return new WaitForSeconds(time);
        createProjectile();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject ob = Instantiate(prefab);
            ob.transform.position = transform.position;
            ob.transform.rotation = transform.rotation;
            Destroy(ob, 3f);
        }
        if (Input.GetKeyDown(shootKey))
        {
            CallShot();
        }
    }
}