using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExecutionScript : MonoBehaviour
{
    public GameObject player;
    public bool stop;
    bool executing = false;
    bool executingFunction = false;
    public GameObject main;
    public GameObject mainBarrier;
    public GameObject function;
    public GameObject functionBarrier;
    public GameObject commmandsBarrier;
    public int currentExecutionLevel;
    Vector3 firstPos;
    Quaternion firstRot;
    public GameObject UIManager;

    public void StartExecuting()
    {
        Debug.Log("Started executing");
        StartCoroutine("ExecuteMain");
    }

	private void Update()
	{
		if(!player)
        {
            player = GameObject.FindWithTag("Player");
        }
	}

	public void Stop()
    {
        stop = true;
    }

    IEnumerator ExecuteMain()
    {
        
        if (!executing)
        {
            currentExecutionLevel = 0;
            stop = false;
            if(UIManager)
            {
                UIManager.GetComponent<UIManagement>().Deselect();

            }
            executing = true;
            mainBarrier.SetActive(true);
            commmandsBarrier.SetActive(true);
            if(functionBarrier)
            functionBarrier.SetActive(true);

            firstPos = player.transform.position;
            firstRot = player.transform.rotation;

            for (int i = 0; i < main.GetComponent<RectTransform>().childCount; i++)
            {
                if (player.GetComponent<PlayerController>().finishedStage)
                {
                    //currentExecutionLevel = -1;
                    //main.GetComponent<RectTransform>().GetChild(i).GetChild(1).gameObject.SetActive(true);
                    //main.GetComponent<RectTransform>().GetChild(i).GetChild(0).gameObject.SetActive(false);
                    ////yield return new WaitForSeconds(0.4f);

                    //foreach (var sample in SampleScript.samples)
                    //{
                    //    Debug.Log("resetting samples");
                    //    sample.SetActive(true);
                    //}
                    //player.GetComponent<PlayerController>().collectedSamples = 0;
                    //player.transform.rotation = firstRot;
                    //player.transform.position = firstPos;
                    break;
                }
                if (stop)
                {
                    currentExecutionLevel = -1;
                    stop = false;
                    //main.GetComponent<RectTransform>().GetChild(i).GetChild(1).gameObject.SetActive(true);
                    //main.GetComponent<RectTransform>().GetChild(i).GetChild(0).gameObject.SetActive(false);
                    yield return new WaitForSeconds(0.4f);
                    //main.GetComponent<RectTransform>().GetChild(i).GetChild(0).gameObject.SetActive(true);
                    main.GetComponent<RectTransform>().GetChild(i).GetChild(1).gameObject.SetActive(false);
                    foreach (var sample in SampleScript.samples)
                    {
                        Debug.Log("resetting samples");
                        sample.SetActive(true);
                    }
                    player.GetComponent<PlayerController>().collectedSamples = 0;
                    player.transform.rotation = firstRot;
                    player.transform.position = firstPos;

                    break;
                }
                //Debug.Log("Child Count: " + main.GetComponent<RectTransform>().childCount);
                //Debug.Log("Child Index: " + i);
                //Debug.Log("" + main.GetComponent<RectTransform>().GetChild(i).name[0]);



                //main.GetComponent<RectTransform>().GetChild(i).GetChild(0).gameObject.SetActive(false);
                main.GetComponent<RectTransform>().GetChild(i).GetChild(1).gameObject.SetActive(true);

                switch ("" + main.GetComponent<RectTransform>().GetChild(i).name[0])
                {
                    case "0":
                        player.GetComponent<PlayerController>().Forward();
                        Debug.Log("Forward");
                        break;
                    case "2":
                        player.GetComponent<PlayerController>().RotateClockwise();

                        Debug.Log("Cw"); break;

                    case "1":
                        player.GetComponent<PlayerController>().RotateCounterClockwise();

                        Debug.Log("ccw"); break;
                    case "3":
                        player.GetComponent<PlayerController>().Jump();

                        Debug.Log("jump");
                        break;
                    case "4":
                        player.GetComponent<PlayerController>().Collect();

                        Debug.Log("collect"); break;
                    case "5":
                        Debug.Log("function");
                        currentExecutionLevel = 1;
                        StartCoroutine(ExecuteFunction(1));
                        while (currentExecutionLevel > 0)
                        {
                            yield return null;
                        }
                        break;
                    default:

                        Debug.Log("default"); break;
                }

                if(currentExecutionLevel == -1)
                {
                    currentExecutionLevel = 0;
                }
                else
                {
                    yield return new WaitForSeconds(0.4f);
                }

                //main.GetComponent<RectTransform>().GetChild(i).GetChild(0).gameObject.SetActive(true);
                main.GetComponent<RectTransform>().GetChild(i).GetChild(1).gameObject.SetActive(false);

            }
            if (!player.GetComponent<PlayerController>().finishedStage)//reset
            {


                foreach (var sample in SampleScript.samples)
                {
                    Debug.Log("resetting samples");
                    sample.SetActive(true);
                }
                player.GetComponent<PlayerController>().collectedSamples = 0;
                player.transform.rotation = firstRot;
                player.transform.position = firstPos;
            }
            mainBarrier.SetActive(false);
            commmandsBarrier.SetActive(false);
            if(functionBarrier)
            functionBarrier.SetActive(false);
            executing = false;
            if(UIManager)
            {
                UIManager.GetComponent<UIManagement>().Reselect();

            }
        }

    }

    IEnumerator ExecuteFunction(int executionLevel)
    {

        //executingFunction = true;

        //commmandsBarrier.SetActive(true);

        // firstPos = player.transform.position;
        //Quaternion firstRot = player.transform.rotation;

        for (int i = 0; i < function.GetComponent<RectTransform>().childCount; i++)
        {
            if (player.GetComponent<PlayerController>().finishedStage)
            {
                currentExecutionLevel = -1;
                //yield return new WaitForSeconds(0.4f);
                //foreach (var sample in SampleScript.samples)
                //{
                //    Debug.Log("resetting samples");
                //    sample.SetActive(true);
                //}
                //player.GetComponent<PlayerController>().collectedSamples = 0;
                //player.transform.rotation = firstRot;
                //player.transform.position = firstPos;
                break;
            }
            if (stop)
            {
                currentExecutionLevel = -1;
                yield return new WaitForSeconds(0.4f);
                stop = false;
                Debug.Log("Stop");

                foreach (var sample in SampleScript.samples)
                {
                    Debug.Log("resetting samples");
                    sample.SetActive(true);
                }
                player.GetComponent<PlayerController>().collectedSamples = 0;
                player.transform.rotation = firstRot;
                player.transform.position = firstPos;


                break;
            }
            //Debug.Log("Child Count: " + function.GetComponent<RectTransform>().childCount);
            //Debug.Log("Child Index: " + i);
            //Debug.Log("" + main.GetComponent<RectTransform>().GetChild(i).name[0]);



            ///function.GetComponent<RectTransform>().GetChild(i).GetChild(0).gameObject.SetActive(false);
            function.GetComponent<RectTransform>().GetChild(i).GetChild(1).gameObject.SetActive(true);

            switch ("" + function.GetComponent<RectTransform>().GetChild(i).name[0])
            {
                case "0":
                    player.GetComponent<PlayerController>().Forward();
                    Debug.Log("fForward");
                    break;
                case "2":
                    player.GetComponent<PlayerController>().RotateClockwise();

                    Debug.Log("fCw"); break;

                case "1":
                    player.GetComponent<PlayerController>().RotateCounterClockwise();

                    Debug.Log("fccw"); break;
                case "3":
                    player.GetComponent<PlayerController>().Jump();

                    Debug.Log("fjump");
                    break;
                case "4":
                    player.GetComponent<PlayerController>().Collect();

                    Debug.Log("fcollect"); break;
                case "5":
                    Debug.Log("ffunction");
                    yield return new WaitForSeconds(0.4f);
                    //function.GetComponent<RectTransform>().GetChild(i).GetChild(0).gameObject.SetActive(true);
                    function.GetComponent<RectTransform>().GetChild(i).GetChild(1).gameObject.SetActive(false);
                    currentExecutionLevel++;
                    StartCoroutine(ExecuteFunction(currentExecutionLevel));

                    while (executionLevel < currentExecutionLevel)
                    {
                        yield return null;
                    }
                    break;
                default:

                    Debug.Log("fdefault"); break;
            }

            if(currentExecutionLevel != -1)
            {
                yield return new WaitForSeconds(0.4f);
            }
            //function.GetComponent<RectTransform>().GetChild(i).GetChild(0).gameObject.SetActive(true);
            function.GetComponent<RectTransform>().GetChild(i).GetChild(1).gameObject.SetActive(false);

        }
        //if (!player.GetComponent<PlayerController>().finishedStage)//reset
        //{
        //    foreach (var sample in SampleScript.samples)
        //    {
        //        sample.SetActive(true);
        //    }
        //    player.GetComponent<PlayerController>().collectedSamples = 0;
        //    player.transform.rotation = firstRot;
        //    player.transform.position = firstPos;
        //}
        executingFunction = false;

        //commmandsBarrier.SetActive(false);
        //executing = false;
        currentExecutionLevel--;
    }

	public void Reset()
	{
        for (int i = 0; i < main.GetComponent<RectTransform>().childCount; i++)
        {
            //main.GetComponent<RectTransform>().GetChild(i).GetChild(0).gameObject.SetActive(true);
            main.GetComponent<RectTransform>().GetChild(i).GetChild(1).gameObject.SetActive(false);  
        }

        foreach (var sample in SampleScript.samples)
        {
            Debug.Log("resetting samples");
            sample.SetActive(true);
        }
        player.GetComponent<PlayerController>().collectedSamples = 0;
        player.transform.rotation = firstRot;
        player.transform.position = firstPos;
	}


}
