﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour
{
    public GameObject pinSet;
    
    private Animator animator;
    private PinCounter pinCounter;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        pinCounter = FindObjectOfType<PinCounter>();
    }
    
    public void RaisePins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseifStanding();
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        GameObject newPins = Instantiate(pinSet);
        newPins.transform.position += new Vector3(0, 20, 0);
    }

    public void PerformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Dont know how to handle End Game yet.");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.GetComponent<Pin>())
        {
            Destroy(collider.gameObject);
        }
    }
}
