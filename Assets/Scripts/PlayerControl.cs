using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{

    public float thrust = 0;
    public Rigidbody rb;
    bool walk = false;
    private float speed;

    [SerializeField] float dragforce;
    [SerializeField] float massforce;
    [SerializeField] int dragsecond;

    //[SerializeField] private Slider slider;
    [SerializeField] GameObject UIcontroller;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = massforce;
    }

    void Update()
    {
        if (UIcontroller.GetComponent<BarControl>().speedef)
        {

            speed = UIcontroller.GetComponent<BarControl>().currentval * thrust;
            if (!walk)
            {
                rb.AddForce(Vector3.right * speed);
                walk = true;
             
                StartCoroutine("surtunme");
            }
            else
            {
               // UIcontroller.GetComponent<BarControl>().progressBar.value = rb.velocity.magnitude;

            }
        }
    }

    IEnumerator surtunme()
    {
        yield return new WaitForSecondsRealtime(dragsecond);
        rb.drag += dragforce;
    }

    
}
