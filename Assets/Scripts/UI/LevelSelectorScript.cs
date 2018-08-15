using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorScript : MonoBehaviour
{
    public void Show()
    {
        CanvasGroup group = GetComponent<CanvasGroup>();
        group.interactable = true;
        group.alpha = 1f;
    }

    public void GoToTestLevel()
    {
        SceneManager.LoadScene("InLevel");
    }

}
