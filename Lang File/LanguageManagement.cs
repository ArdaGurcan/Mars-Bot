using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManagement : MonoBehaviour
{
    //public Text cameraMenuButton;
    //public Text nextLevel;
    //public Text menu;
    //public Text execute;
    //public Text stop;
    //public Text forward;
    //public Text collect;
    //public Text clockwise;
    //public Text counteClockwise;

    Text gonextLevel;
    Text gomenu;
    Text levelEditor;
    Text play;
    Text backToDesign;
    Text mainText;
    Text functionText;
    Text completedText;

    GameObject popup;
    
    public string[] commandTextTurkish = { "İleri" ,"Saat Yönü Tersi ", "Saat Yönü", "Zıpla", "Topla", "Fonksiyon"};
    
    public string[] commandTextEnglish = { "Forward", "Counter Clockwise", "Clockwise", "Jump", "Collect", "Function" };


    public static int language = 0;


	private void Start()
	{
        popup = GameObject.Find("Popup");
        if(popup)
            popup.SetActive(true);

        if (GameObject.Find("Completed Text"))
            completedText = GameObject.Find("Completed Text").GetComponent<Text>();
        if (GameObject.Find("Function Text"))
            functionText = GameObject.Find("Function Text").GetComponent<Text>();
        if (GameObject.Find("Main Text"))
            mainText = GameObject.Find("Main Text").GetComponent<Text>();
        if (GameObject.Find("Continue Button"))
            backToDesign = GameObject.Find("Continue Button").transform.GetChild(0).gameObject.gameObject.GetComponent<Text>();
        if(GameObject.Find("Next Level Button"))
            gonextLevel = GameObject.Find("Next Level Button").transform.GetChild(0).gameObject.gameObject.GetComponent<Text>();
        if (GameObject.Find("Menu Button"))
            gomenu = GameObject.Find("Menu Button").transform.GetChild(0).gameObject.gameObject.GetComponent<Text>();
        if (GameObject.Find("Editor Button"))
            levelEditor = GameObject.Find("Editor Button").transform.GetChild(0).gameObject.GetComponent<Text>().gameObject.GetComponent<Text>();
        if (GameObject.Find("Play Button"))
            play = GameObject.Find("Play Button").transform.GetChild(0).gameObject.GetComponent<Text>().gameObject.GetComponent<Text>();
        if(popup)
            popup.SetActive(false);

        switch(language)
        {
            case 0:
                
                if(gonextLevel)
                    gonextLevel.text = "Next Level";
                if(gomenu)
                    gomenu.text = "Menu";
                if (levelEditor)
                    levelEditor.text = "LEVEL EDITOR";
                if (backToDesign)
                    backToDesign.text = "Back to Design";
                if (play)
                    play.text = "PLAY";
                if (functionText)
                    functionText.text = "FUNCTION";
                if (mainText)
                    mainText.text = "MAIN";
                if (completedText)
                    completedText.text = "Level Completed!";
                break;
            case 1:

                if(gonextLevel)    
                    gonextLevel.text = "Sonraki Seviye";
                if(gomenu)
                    gomenu.text = "Menü";
                if (levelEditor)
                    levelEditor.text = "SEViYE TASARLAMA";
                if (backToDesign)
                    backToDesign.text = "Tasarlamaya Dön";
                if (play)
                    play.text = "OYNA";
                if (functionText)
                    functionText.text = "FONKSiYON";
                if (mainText)
                    mainText.text = "ANA";
                if (completedText)
                    completedText.text = "Seviye Geçildi!";
                break;

        }

	}

	private void Update()
	{
        switch (language)
        {
            case 0:
                
                break;
            default:
                break;
        }
	}

    public void ChangeLanguage(int lang)
    {
        language = lang;

        switch (language)
        {
            case 0:

                if (gonextLevel)
                    gonextLevel.text = "Next Level";
                if (gomenu)
                    gomenu.text = "Menu";
                if (levelEditor)
                    levelEditor.text = "LEVEL EDITOR";
                if (backToDesign)
                    backToDesign.text = "Back to Design";
                if (play)
                    play.text = "PLAY";
                if (functionText)
                    functionText.text = "FUNCTION";
                if (mainText)
                    mainText.text = "MAIN";
                if (completedText)
                    completedText.text = "Level Completed!";
                break;
            case 1:

                if (gonextLevel)
                    gonextLevel.text = "Sonraki Seviye";
                if (gomenu)
                    gomenu.text = "Menü";
                if (levelEditor)
                    levelEditor.text = "SEViYE TASARLAMA";
                if (backToDesign)
                    backToDesign.text = "Tasarlamaya Dön";
                if (play)
                    play.text = "OYNA";
                if (functionText)
                    functionText.text = "FONKSiYON";
                if (mainText)
                    mainText.text = "ANA";
                if (completedText)
                    completedText.text = "Seviye Geçildi!";
                break;

        }
    }
}
