using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PostProcessing;

public class Powerups : MonoBehaviour {

    private movement movementScript;
    private Text infoText;
    private CanvasGroup infoCanvas;

    [SerializeField]
    PostProcessingProfile post;

	void Start () {

        movementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<movement>();
        infoText = GameObject.FindGameObjectWithTag("infoText").GetComponent<Text>();
        infoCanvas = GameObject.FindGameObjectWithTag("infoText").GetComponent<CanvasGroup>();
    }

    public void Power()
    {
        int rand = Random.Range(0, 4);

        switch (rand)
        {
            case 0:
                movementScript.StartCoroutine("PowerUP");
                InfoPower("speed down", true);
                break;
            case 1:
                movementScript.StartCoroutine("PowerDOWN");
                InfoPower("speed up", false);
                break;
            case 2:
                movementScript.ExtraPoints();
                InfoPower("extra points", true);
                break;
            case 3:
                StartCoroutine("Noise");
                InfoPower("noise", false);
                break;
        }
        StartCoroutine("InfoRoutine");
    }

    private void InfoPower(string powerText, bool good)
    {
        if (good)
            infoText.color = Color.green;
        else
            infoText.color = Color.red;

        infoText.text = powerText;
    }

    IEnumerator InfoRoutine() 
    {
        infoCanvas.alpha = 1.0f;
        infoCanvas.blocksRaycasts = true;

        yield return new WaitForSeconds(2.0f);

        infoCanvas.alpha = 0f;
        infoCanvas.blocksRaycasts = false;
    }
     
    IEnumerator Noise() 
    {
        post.grain.enabled = true;

        yield return new WaitForSeconds(4.0f);

        post.grain.enabled = false;
    }

}
