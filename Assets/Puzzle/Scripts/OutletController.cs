using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutletController : MonoBehaviour
{
    public bool IsConnecting { get; private set; }

    public void Connect()
    {
        IsConnecting = true;
    }

    public void Disconnect()
    {
        IsConnecting = false;
    }
}
