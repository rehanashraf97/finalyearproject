using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public Material matRed;
    public Material matGreen;
    public GameObject Sphere;

    // Start is called before the first frame update
    // GetComponent<Renderer>().material = matRed;
    public void MatRed()
    {
        GameObject sphereBall = GameObject.Find("Sphere");
        sphereBall.GetComponent<Renderer>().material = matRed;

    }

    public void MatGreen()
    {
        GameObject sphereBall = GameObject.Find("Sphere");
        sphereBall.GetComponent<Renderer>().material = matGreen;
    }
    
}
