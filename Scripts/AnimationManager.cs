using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;


public class AnimationManager : MonoBehaviour
{
    Animator animator;
    string destination;
    public int world;
    public int level;
    public Text[] levelNames;
    public Text title;
    public GameObject fadeImage;
    public GameObject back;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        back.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (back.activeSelf && animator.GetInteger("State") == 0)
        {
            back.SetActive(false);
        }
        else if (animator.GetInteger("State") != 0)
        {
            back.SetActive(true);
        }
    }

    public void GoBack()
    {
        animator.SetTrigger("Back");
        animator.SetInteger("State", animator.GetInteger("State") - 1);
    }


    public void StartGame()
    {
        animator.SetInteger("State", 1);
    }

    public void WorldSelect(int targetWorld)
    {
        world = targetWorld;
        animator.SetInteger("State", 2);
        for (int i = 0; i < levelNames.Length; i++)
        {
            levelNames[i].text = (world + 1) + "-" + (i+1);
        }
        if(LanguageManagement.language == 0)
            title.text = "Sector " + (world + 1);
        else if(LanguageManagement.language == 1)
            title.text = "Bölge " + (world + 1);


    }

    public void LevelSelect(int targetLevel)
    {
        level = targetLevel;
        fadeImage.GetComponent<Animator>().SetBool("Light", false);
        //SceneManager.LoadScene("Level" + ((world >= 10) ? "" : "0") + (world + 1) + "-" + ((level >= 10) ? "" : "0") + (level+1));
    }

}
