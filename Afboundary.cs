using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Afboundary : LastReg
{
     void Update()
    {
        if (Triggered)
        {
            boundaryUI();
            //Debug.Log("triggered2");
            //Debug.Log(lastreg);
            //Debug.Log(Thisreg);
            Triggered = false;
        }
    }

    public virtual void boundaryUI()
    {
        Thisreg = " Africa (excl. MENA)";
        if (lastreg != Thisreg)
        {
            //Debug.Log(" Africa (excl. MENA)");
            PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
            pop.PopUp("<size=10>" + "Africa (excl. MENA)" + "</size>");
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
