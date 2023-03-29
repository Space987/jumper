using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public void PickupDoubleJump()
    {
        gameObject.SetActive(false);
        Invoke(nameof(TimerPickup), 30f);

    }

    public void TimerPickup()
    {
        gameObject.SetActive(true);
    }
}
