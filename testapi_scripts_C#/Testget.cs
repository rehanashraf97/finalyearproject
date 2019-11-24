using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleJSON;


public class Testget : MonoBehaviour
{
    public GameObject success_msg;
    public GameObject loadingTextPanel;
    public Text errortxt;
    public Image panelColor; 
    public InputField first_name;
    public InputField last_name;
    public InputField email;
    public InputField password;
    public Text loadingText;
    string userName;
    string userLastName;
    string userEmail;
    string userPassword;
    public int user_id;

    void Start()
    {
        // A correct website page.
        //StartCoroutine(GetRequest("https://www.example.com"));

        // A non-existing page.
        //StartCoroutine(GetRequest("https://error.html"));
        //StartCoroutine(RegisterUser("unity1@gmail.com","123","unity1","test1","shop"));
        Debug.Log(user_id);

    }

    public void landingFuc(int user)
    {
        Debug.Log(user);
    }

    void Update()
    {
       // Debug.Log("HELLO");
    }

        public void getFormValue()
    {

        userName = first_name.text;
        userLastName = last_name.text;
        userEmail = email.text;
        userPassword = password.text;
        StartCoroutine(RegisterUser(userEmail, userPassword, userName, userLastName, "customer"));
    }

    public void getLogin()
    {
        userEmail = email.text;
        userPassword = password.text;
        StartCoroutine(LoginUser(userEmail, userPassword));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost:8080/furniture/api/furniture/brand?user_id=1"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                var getData = webRequest.downloadHandler.text;
                var N = JSON.Parse(getData);
                Debug.Log(N["msg"]);
            }
        }
    }

    IEnumerator RegisterUser(string email, string password, string first_name , string last_name, string type)
    {
        WWWForm form = new WWWForm();
        form.AddField("token", "rTx8fj@Furn!turec6fYQR4$!");
        form.AddField("email", email);
        form.AddField("password", password);
        form.AddField("first_name", first_name);
        form.AddField("last_name", last_name);
        form.AddField("type", type);
        loadingTextPanel.SetActive(true);
        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://furniturear.creativeparams.com/api/furniture/signup", form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(webRequest.error);
                loadingTextPanel.SetActive(false);
                panelColor.color = new Color(1, 0, 0, 0.5f);
                errortxt.text = "Connection Error";
                success_msg.SetActive(true);
                yield return new WaitForSeconds(2);
                panelColor.color = new Color(1, 0, 0, 0);
                success_msg.SetActive(false);
            }
            else
            {
                var getData = webRequest.downloadHandler.text;
                loadingTextPanel.SetActive(false);
                var signupReq = JSON.Parse(getData);
                var status = signupReq["status"];
                Debug.Log(signupReq);
                if (status.AsInt == 0)
                {
                    // if -1 means fields are empty
                    // if -2 means email should be unique
                    if(signupReq["code"].AsInt == -1)
                    {
                        panelColor.color = new Color(1, 0, 0, 0.5f);
                        errortxt.text = signupReq["msg"];
                        success_msg.SetActive(true);
                        yield return new WaitForSeconds(2);
                        panelColor.color = new Color(1, 0, 0, 0);
                        success_msg.SetActive(false);
                    }
                    else if (signupReq["code"].AsInt == -2)
                    {
                        panelColor.color = new Color(1, 0, 0, 0.5f);
                        errortxt.text = "Email Already Exist";
                        success_msg.SetActive(true);
                        yield return new WaitForSeconds(2);
                        panelColor.color = new Color(1, 0, 0, 0);
                        success_msg.SetActive(false);
                    }
                    
                }
                else
                {
                    
                    panelColor.color = new Color(0, 1, 0,0.5f);
                    errortxt.text = "Account Created Sucessfully!";
                    success_msg.SetActive(true);
                    yield return new WaitForSeconds(2);
                    panelColor.color = new Color(1, 0, 0, 0);
                    success_msg.SetActive(false);
                    SceneManager.LoadScene("signin");
                }
                
                
            }
        }
    }

    IEnumerator LoginUser(string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("token", "rTx8fj@Furn!turec6fYQR4$!");
        form.AddField("email", email);
        form.AddField("password", password);
        loadingTextPanel.SetActive(true);
        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://furniturear.creativeparams.com/api/furniture/login", form))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log(webRequest.error);
                loadingTextPanel.SetActive(false);
                panelColor.color = new Color(1, 0, 0, 0.5f);
                errortxt.text = "Connection Error";
                success_msg.SetActive(true);
                yield return new WaitForSeconds(2);
                panelColor.color = new Color(1, 0, 0, 0);
                success_msg.SetActive(false);
            }
            else
            {
                var getData = webRequest.downloadHandler.text;
                loadingTextPanel.SetActive(false);
                var loginReq = JSON.Parse(getData);
                if (loginReq["code"].AsInt == -1)
                {
                    panelColor.color = new Color(1, 0, 0, 0.5f);
                    errortxt.text = "Invalid Email And Password";
                    success_msg.SetActive(true);
                    yield return new WaitForSeconds(3);
                    panelColor.color = new Color(1, 0, 0, 0);
                    success_msg.SetActive(false);
                }else
                {
                    var get_user_id = loginReq["data"][0]["id"];
                    var get_user_first_name = loginReq["data"][0]["first_name"];
                    panelColor.color = new Color(0, 1, 0, 0.5f);
                    errortxt.text = "SignIn Sucessfully!";
                    success_msg.SetActive(true);
                    yield return new WaitForSeconds(3);
                    panelColor.color = new Color(1, 0, 0, 0);
                    success_msg.SetActive(false);
                    yield return new WaitForSeconds(1);
                    user_id = get_user_id.AsInt;
                    var user_first_name = get_user_first_name;
                    StaticClass.CrossSceneInformation = user_id;
                    //Debug.Log(user_id);
                    StaticClass.first_name = user_first_name;
                    SceneManager.LoadScene("landingscreen");
                    
                }

            }
        }
    }
}
