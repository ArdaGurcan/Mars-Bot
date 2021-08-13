using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class CommandScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    LanguageManagement languageManager;
    Vector3 difference;
    bool beingDragged;
    Transform lastParent;
    public Transform currentArea;
    GameObject placeholder;
    public Transform closestCommand;

    public void DeleteSelf()
    {
        if(!beingDragged)
        {
            Destroy(gameObject);
        }

    }

	private void Start()
	{
        //transform.GetChild(1).GetComponent<Image>().color = new Color(Random.RandomRange(0.5f, 1f), Random.RandomRange(0.5f, 1f), Random.RandomRange(0.5f, 1f));
        transform.GetChild(1).gameObject.SetActive(false);
        languageManager = GameObject.Find("Language Manager").GetComponent<LanguageManagement>();
        Debug.Log((int)name[0]);

        switch (LanguageManagement.language)
        {
            case 0:
                transform.GetChild(2).GetComponent<Text>().text = languageManager.commandTextEnglish[int.Parse(""+name[0])];
                break;
            case 1:
                transform.GetChild(2).GetComponent<Text>().text = languageManager.commandTextTurkish[int.Parse("" + name[0])];
                break;
            default:
                break;
        }

	}

    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        beingDragged = true;

        placeholder = new GameObject();
        placeholder.transform.parent = transform.parent;
        placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());
        LayoutElement layoutElement = placeholder.AddComponent<LayoutElement>();
        layoutElement.preferredWidth = 80;
        layoutElement.preferredHeight = 80;


        GetComponent<Image>().raycastTarget = false;
        lastParent = transform.parent;
        transform.parent = transform.root;
        difference = (Vector2)transform.position - pointerEventData.position;
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        transform.position = pointerEventData.position + (Vector2)difference;

        if(currentArea)
        {
            placeholder.transform.parent = currentArea;

            Transform command = transform;
            Transform closest = currentArea.GetChild(0);

            for (int i = 1; i < currentArea.childCount; i++)
            {
                if (Vector3.Distance(currentArea.GetChild(i).position, command.position) < Vector3.Distance(closest.position, command.position)
                    && currentArea.GetChild(i) != command)
                {
                    closest = currentArea.GetChild(i);
                }
            }
            closestCommand = closest;

            Debug.Log("Closest: " + closest.name);

            // closest.transform.localScale *= 1.2f;
            if (Mathf.Abs(closest.position.y - command.position.y) < 55)
            {
                if (command.position.x > closest.position.x + 40)
                {
                    placeholder.transform.SetSiblingIndex(closest.GetSiblingIndex() + 1);
                }
                else
                {
                    placeholder.transform.SetSiblingIndex(closest.GetSiblingIndex());


                }
            }
            else
            {
                placeholder.transform.SetSiblingIndex(currentArea.childCount);   
            }

        }
            
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        Destroy(placeholder);
        GetComponent<Image>().raycastTarget = true;
        beingDragged = false;
        if(lastParent.GetComponent<DropArea>().pointerOver)
        {
            //transform.parent = lastParent;
        }
        if (transform.parent == transform.root)
        {
            Destroy(gameObject);
        }

    }

	private void Update()
	{
	}


}
