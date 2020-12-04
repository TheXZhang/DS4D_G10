using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APboundary :LastReg
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
        Thisreg = "Asia and Pacific_Boundary";
        if (lastreg != Thisreg)
        {
            //Debug.Log("Asia and Pacific_Boundary");
            PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
            pop.PopUp("<size=10>" + "Asia and Pacific" + "</size>");
            lastreg = Thisreg;
           // StartCoroutine(PopUpSystem.DelayFuc(() => { pop.Close(); }, 3.0f));
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
