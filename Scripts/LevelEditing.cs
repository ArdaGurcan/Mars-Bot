using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelEditing : MonoBehaviour
{
    public GameObject blockPrefab;
    public GameObject samplePrefab;
    public GameObject playerPrefab;
    public GameObject environment;
    public LayerMask notPlaceable;
    public PlayerController player;
    public GameObject commandBar;
    public GameObject blockBar;
    public int place = 0;
    // Start is called before the first frame update
    void Start()
    {
        blockBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(Camera.main.ScreenToWorldPoint(Input.mousePosition),Camera.main.transform.position);

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Camera.main.GetComponent<LineRenderer>().SetPosition(0, Camera.main.transform.position);
        if(Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) && !EventSystem.current.IsPointerOverGameObject())
        {
            switch(place)
            {
                case 0:
                    if(hit.transform.name.Contains("Cube") || hit.transform.name.Contains("Sample") || hit.transform.name.Contains("Player"))
                    {
                        Destroy(hit.transform.gameObject);
                    }
                    break;
                case 1:
                    if(hit.transform.gameObject.layer != 9)
                    {
                        Instantiate(blockPrefab, new Vector3(Mathf.Round(hit.point.x + 0.0001f), Mathf.Round(hit.point.y - 0.0001f) - 0.5f, Mathf.Round(hit.point.z + 0.0001f)) + hit.normal, Quaternion.identity);

                    }
                    break;
                case 2:
                    if (hit.transform.gameObject.layer != 9)
                    if(!GameObject.FindWithTag("Player"))
                        Instantiate(playerPrefab, new Vector3(Mathf.Round(hit.point.x + 0.0001f), Mathf.Round(hit.point.y - 0.0001f) - 0.5f, Mathf.Round(hit.point.z + 0.0001f)) + hit.normal, Quaternion.identity);

                    break;
                case 3:
                    if (hit.transform.gameObject.layer != 9)
                    {
                        Instantiate(samplePrefab, new Vector3(Mathf.Round(hit.point.x + 0.0001f), Mathf.Round(hit.point.y - 0.0001f) - 1f + 0.96f, Mathf.Round(hit.point.z + 0.0001f)) + hit.normal, Quaternion.Euler(new Vector3(-90, 0, 0)));
                    }

                    break;
            }

        }

    }

    public void SetBlock(int blockId)
    {
        place = blockId;
    }

    public void SwapCommandBars()
    {
        commandBar.SetActive(!commandBar.activeSelf);
        blockBar.SetActive(!blockBar.activeSelf);
    }
}
