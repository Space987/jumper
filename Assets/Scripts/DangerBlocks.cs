using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerBlocks : MonoBehaviour
{
    // Update is called once per frame
   public float rotateSpeed = 5f;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0,10,0)*rotateSpeed*Time.deltaTime);
    }

   void OnCollisionEnter(Collision other) {
    if (other.transform.tag == "SpinnyRec")
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("This hit");
    }
   } 
}
