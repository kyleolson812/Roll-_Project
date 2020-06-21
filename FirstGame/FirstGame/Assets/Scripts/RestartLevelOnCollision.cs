using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
