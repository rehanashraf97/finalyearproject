using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagment : MonoBehaviour
{
    public void GotoLandingScene()
    {
        SceneManager.LoadScene("landingscreen");
    }

    public void GotoAboutScene()
    {
        SceneManager.LoadScene("aboutus");
    }

    public void GotoCategoryScene()
    {
        SceneManager.LoadScene("category");
    }

    public void GotoPrtoductDetailScene()
    {
        SceneManager.LoadScene("productdetail");
    }

    public void GotoSigninSignupScene()
    {
        SceneManager.LoadScene("signin_signup");
    }

    public void GotoSigninScene()
    {
        SceneManager.LoadScene("signin");
    }

    public void GotoSignupScene()
    {
        SceneManager.LoadScene("signup");
    }

    public void GotoUserProfileScene()
    {
        SceneManager.LoadScene("userprofile");
    }
}
