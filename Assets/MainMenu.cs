using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void Credits(){
  
  	SceneManager.LoadScene("Credits");
  	
  }
  
  public void StartGame(){
  
 	 SceneManager.LoadScene("Fase1");


	}
  
  
}