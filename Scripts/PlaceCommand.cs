using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaceCommand : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Vector3 difference;
    public GameObject commandPrefab;
    public GameObject command;
    public Transform parent;
    public GameObject forward;
    public GameObject cw;
    public GameObject ccw;
    public GameObject jump;
    public GameObject collect;
    public GameObject function;
    GameObject placeholder;
    public Transform currentArea;

    public void AddCommand(int command)
    {
        if (parent.childCount < 12)
        {
            switch (command)
            {
                case 1:
                    Instantiate(forward, parent);
                    break;
                case 2:
                    Instantiate(cw, parent);
                    break;
                case 3:
                    Instantiate(ccw, parent);
                    break;
                case 4:
                    Instantiate(jump, parent);
                    break;
                case 5:
                    Instantiate(collect, parent);
                    break;
                case 6:
                    Instantiate(function, parent);
                    break;
                default:
                    break;
            }
        }

    }

    public void OnBeginDrag(PointerEventData pointerEventData)
    {
        difference = (Vector2)transform.position - pointerEventData.position;
        command = Instantiate(commandPrefab, transform.position, Quaternion.identity, transform.root);

        placeholder = new GameObject();

        LayoutElement layoutElement = placeholder.AddComponent<LayoutElement>();
        layoutElement.preferredWidth = 80;
        layoutElement.preferredHeight = 80;
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        command.transform.position = pointerEventData.position + (Vector2)difference;
        if(currentArea)
        {
            placeholder.transform.parent = currentArea;

            Transform closest = currentArea.GetChild(0);

            for (int i = 1; i < currentArea.childCount; i++)
            {
                if (Vector3.Distance(currentArea.GetChild(i).position, command.transform.position) < Vector3.Distance(closest.position, command.transform.position)
                    && currentArea.GetChild(i) != command)
                {
                    closest = currentArea.GetChild(i);
                }
            }
            //closestCommand = closest;

            Debug.Log("Closest: " + closest.name);

            // closest.transform.localScale *= 1.2f;
            if (Mathf.Abs(closest.position.y - command.transform.position.y) < 55)
            {
                if (command.transform.position.x > closest.position.x + 40)
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
        if(command.transform.parent == transform.root)
        {
            Destroy(command);
        }
    }

}
