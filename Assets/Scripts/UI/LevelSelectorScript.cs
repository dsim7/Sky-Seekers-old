using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _levelSelector;

    public void Show()
    {
        CanvasGroup group = GetComponent<CanvasGroup>();
        group.interactable = true;
        group.alpha = 1f;
    }

    public void ShowLevelSelector()
    {
        _levelSelector.GetComponent<Animator>().SetTrigger("Appear");
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("InLevel");
    }

}
