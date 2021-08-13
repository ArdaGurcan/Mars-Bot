using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMasterCaller : MonoBehaviour
{
    [SerializeField]
    GameObject master;
    public AnimationManager animationManager;

	
	public void FadeToDark()
    {
        animationManager = Camera.main.GetComponent<AnimationManager>();
        if (master.GetComponent<SceneMaster>().loadMenu)
            ReturnToMenu();
        else
            NextLevel();
    }

    public void NextLevel()
    {
        
    }

    public void LoadLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            animationManager = Camera.main.gameObject.GetComponent<AnimationManager>();
            SceneManager.LoadScene("Level" + ((animationManager.world >= 10) ? "" : "0") + (animationManager.world + 1) + "-" + ((animationManager.level >= 10) ? "" : "0") + (animationManager.level + 1));
        }
        else
        {
            animationManager = Camera.main.GetComponent<AnimationManager>();
            if (SceneManager.GetActiveScene().buildIndex + 1 != SceneManager.sceneCountInBuildSettings && master.GetComponent<SceneMaster>().loadMenu == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
            else
                ReturnToMenu();
        }

    }

    public void LoadLevelEditor()
    {
        animationManager = Camera.main.GetComponent<AnimationManager>();
        SceneManager.LoadScene("Level Editor");
    }

    public void ReturnToMenu()
    {
        animationManager = Camera.main.GetComponent<AnimationManager>();
        SceneManager.LoadScene(1);
    }



}
