using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WelcomeHandler : MonoBehaviour {

	public void StartClicked(){
        Debug.Log("Start Clicked");

        SceneManager.LoadScene("GamePlay");
    }

    public void HelpClicked()
    {

    }

    public void StatsClicked()
    {

    }

    public void QuitClicked()
    {

    }
}
