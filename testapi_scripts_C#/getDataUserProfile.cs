using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class getDataUserProfile : MonoBehaviour
{

    public Text username; 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(StaticClass.CrossSceneInformation);
        Debug.Log(StaticClass.first_name );
        username.text = StaticClass.first_name;
    }
    public void LogOutUser()
    {
        StaticClass.CrossSceneInformation = 0;
        StaticClass.first_name = null;
        SceneManager.LoadScene("landingscreen");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
