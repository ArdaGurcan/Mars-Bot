using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropArea : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool pointerOver;
    Transform command;

	private void Start()
	{
		
	}

	public void OnPointerEnter(PointerEventData pointerEventData)
    {
        pointerOver = true;

        if (pointerEventData.pointerDrag && pointerEventData.pointerDrag.GetComponent<CommandScript>())
            pointerEventData.pointerDrag.GetComponent<CommandScript>().currentArea = transform;

        if (pointerEventData.pointerDrag && pointerEventData.pointerDrag.GetComponent<PlaceCommand>())
            pointerEventData.pointerDrag.GetComponent<PlaceCommand>().currentArea = transform;
        Debug.Log("Enter");
    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        Debug.Log("Drop");
        if(pointerEventData.pointerDrag.GetComponent<PlaceCommand>())
        {
            pointerEventData.pointerDrag.GetComponent<PlaceCommand>().command.transform.parent = transform;
            command = pointerEventData.pointerDrag.GetComponent<PlaceCommand>().command.transform;

        }
        else if(pointerOver)
        {
            pointerEventData.pointerDrag.transform.parent = transform;
            command = pointerEventData.pointerDrag.transform;

        }



        Transform closest = transform.GetChild(0);

        for (int i = 1; i < transform.childCount; i++)
        {
            if(Vector3.Distance(transform.GetChild(i).position, command.position) < Vector3.Distance(closest.position, command.position)
               && transform.GetChild(i) != command)
            {
                closest = transform.GetChild(i);
            }
        }
        Debug.Log(Vector3.Distance(closest.position, command.position));

       // closest.transform.localScale *= 1.2f;
        if(Mathf.Abs(closest.position.y- command.position.y) < 55)
        {
            if (command.position.x > closest.position.x)
            {
                command.SetSiblingIndex(closest.GetSiblingIndex() + 1);
            }
            else
            {
                command.SetSiblingIndex(closest.GetSiblingIndex());

            }
        }

    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        pointerOver = false;
        Debug.Log("Exit");
        if(pointerEventData.pointerDrag)
        {
            if(pointerEventData.pointerDrag.GetComponent<PlaceCommand>())
            {
                Debug.Log("Button");
                pointerEventData.pointerDrag.GetComponent<PlaceCommand>().command.transform.parent = transform.root;
            }
            else
            {
                Debug.Log("Command");
                pointerEventData.pointerDrag.transform.parent = transform.root;
            }
        }

        if(pointerEventData.pointerDrag && pointerEventData.pointerDrag.GetComponent<CommandScript>())
            pointerEventData.pointerDrag.GetComponent<CommandScript>().currentArea = null;

    }

	private void Update()
	{
        if (pointerOver)
            Debug.Log("Mouse over");
	}



}
