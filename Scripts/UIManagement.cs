using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement : MonoBehaviour
{
    public bool mainSelected = true;
    public GameObject main;
    public GameObject function;
    public GameObject mainButton;
    public GameObject functionButton;

    public GameObject commands;

    public Color mainDefault;
    public Color mainHighlight;
    public Color functionDefault;
    public Color functionHighlight;


    public void SelectMain()
    {
        //if (!mainSelected)
        //{
            main.GetComponent<Image>().color = mainHighlight;
            function.GetComponent<Image>().color = functionDefault;
            mainButton.SetActive(false);
            functionButton.SetActive(true);
            mainSelected = true;

            for (int i = 0; i < commands.transform.childCount; i++)
            {
                commands.transform.GetChild(i).GetComponent<PlaceCommand>().parent = main.transform;
            }
        //}
    }

    public void SelectFunction()
    {
        //if (mainSelected)
        //{
            main.GetComponent<Image>().color = mainDefault;
            function.GetComponent<Image>().color = functionHighlight;
            mainButton.SetActive(true);
            functionButton.SetActive(false);
            mainSelected = false;

            for (int i = 0; i < commands.transform.childCount; i++)
            {
                if(commands.transform.GetChild(i).GetComponent<PlaceCommand>()){
                    commands.transform.GetChild(i).GetComponent<PlaceCommand>().parent = function.transform;

                }
            }
        //}
    }

    public void Deselect(){
        main.GetComponent<Image>().color = mainDefault;
        function.GetComponent<Image>().color = functionDefault;
        mainButton.SetActive(false);
        functionButton.SetActive(true);

    }

    public void Reselect(){
        if(mainSelected)
        {
            SelectMain();
        }
        else
        {
            SelectFunction();    
        }
    }
}
