using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SignPost : MonoBehaviour
{	
	public void ResetScene(string sceneName) 
	{
		SceneManager.LoadScene(sceneName);
	}
}