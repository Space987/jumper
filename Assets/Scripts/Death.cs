using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) 
   {
        if (other.tag == "Player")
        {
            GameManager.Instance.ResetScore();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
   }
}
