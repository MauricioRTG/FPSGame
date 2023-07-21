using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterPortal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out Portal portal))
        {
            GoToNextRound();
        }
    }

    public void GoToNextRound()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int NextRound = currentSceneIndex + 1;
        SceneManager.LoadScene(NextRound);
    }
}
