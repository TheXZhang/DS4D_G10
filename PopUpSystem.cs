using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public Text popUpText;

    public GameObject InstructionBox;
    public Animator Instructionanimator;
    public Text InstructionText;

    public GameObject InfoBox;
    public Animator Infoanimator;
    public Text InfoText;

    void start()
    {
        popUpBox.SetActive(false);
        InstructionBox.SetActive(false);
        InfoBox.SetActive(false);

    }

    public static IEnumerator DelayFuc(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }

    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        animator.SetTrigger("pop");
        StartCoroutine(DelayFuc(() => { popUpBox.SetActive(false); }, 3.0f));
    }

    public void PopUpInstru(string text)
    {
        InstructionBox.SetActive(true);
        InstructionText.text = text;
        Instructionanimator.SetTrigger("pop");
        //StartCoroutine(DelayFuc(() => { InstructionBox.SetActive(false); }, 3.0f));
    }

    public void PopUpInfo(string text)
    {
        InfoBox.SetActive(true);
        InfoText.text = text;
        Infoanimator.SetTrigger("pop");
        //StartCoroutine(DelayFuc(() => { InstructionBox.SetActive(false); }, 3.0f));
    }

    /* public void Close()
     {
         animator.SetTrigger("close");
     }*/
}
