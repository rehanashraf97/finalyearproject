using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class getDataLanding : MonoBehaviour
{
    public GameObject signinBtn;
    public GameObject profileBtn;
    // Start is called before the first frame update
    void Start()
    {
       var user_id = StaticClass.CrossSceneInformation;
       var first_name = StaticClass.first_name;
        if(user_id == 0)
        {
            signinBtn.SetActive(true);
            profileBtn.SetActive(false);
        }else if(user_id > 0)
        {
            signinBtn.SetActive(false);
            profileBtn.SetActive(true);
        }
    }

    public void GotoUserProfileScene()
    {
        SceneManager.LoadScene("userprofile");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
