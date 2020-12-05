using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MEboundary : LastReg
{
    // Start is called before the first frame update
    void Update()
    {
        if (Triggered)
        {
            boundaryUI();
            //Debug.Log("triggered");
            //Debug.Log(lastreg);
            //Debug.Log(Thisreg);
            Triggered = false;
        }
    }

    public virtual void boundaryUI()
    {
        Thisreg = "Middle East and North Africa";
        if (lastreg != Thisreg)
        {
            //Debug.Log("Middle East and North Africa");
            PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
            pop.PopUp("<size=10>" + "Middle East \n and North Africa" + "</size>");
            lastreg = Thisreg;
            //StartCoroutine(PopUpSystem.DelayFuc(() => { pop.Close(); }, 3.0f));
        }

    }
    public virtual void OnTriggerExit(Collider mCollider)
    {
        if (mCollider.gameObject.tag == "Player")
        {
            Triggered = true;
        }
    }
}
