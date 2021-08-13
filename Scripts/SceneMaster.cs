using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : MonoBehaviour
{
    float offlineTime;
    float maxOfflineTime = 300f;
    public GameObject popup;
    public GameObject fadeImage;
    public bool loadMenu;
    ExecutionScript execute;


	public void NextScene()
    {
        loadMenu = false;
        fadeImage.GetComponent<Animator>().SetBool("Light", false);
    }


	public void LoadMenu()
    {
        loadMenu = true;
        fadeImage.GetComponent<Animator>().SetBool("Light", true);
        if(SceneManager.GetActiveScene().buildIndex >= 0)
        {
            fadeImage.GetComponent<Animator>().SetBool("Light", false);
        }
    }

    public void ShowPopup()
    {
        popup.SetActive(true);
    }

    public void HidePopup()
    {
        PlayerController player;
        
        execute = GameObject.Find("Executer").GetComponent<ExecutionScript>();
        execute.Reset();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        player.finishedStage = false;
        player.shownPopup = false;
        popup.SetActive(false);   
    }

    public void GoToLevelEditor()
    {
        loadMenu = false;
        fadeImage.GetComponent<Animator>().SetTrigger("Level Editor");
    }

	private void Update()
	{
        if(Input.anyKey)
        {
            offlineTime = 0;
        }
        else
        {
            offlineTime += Time.deltaTime;
            if(offlineTime >= maxOfflineTime)
            {
                LoadMenu();
            }

        }
	}
}
