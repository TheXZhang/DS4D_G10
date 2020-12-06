using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastReg : MonoBehaviour
{

    protected static string lastreg = "a";
    protected string Thisreg = "";
    protected bool Triggered = false;
    protected virtual void ListThisReg() { }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Triggered)
        {
            boundaryUI();
        }
    }

    public virtual void boundaryUI()
    {
        
        if (lastreg != Thisreg)
        {
            Debug.Log(Thisreg);
            lastreg = Thisreg;
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
