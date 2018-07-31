using System.Collections;
using UnityEngine;

public class MainMenuIntro : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject logo;
    [SerializeField]
    private GameObject playButton;
    [SerializeField]
    private GameObject exitButton;
    [SerializeField]
    private GameObject introText;
    [SerializeField]
    private GameObject cameraTarget;

    Animator screenAnimator, logoAnimator, playAnimator, exitAnimator, introTextAnimator, cameraTargetAnimator;

    void Start()
    {
        screenAnimator = GetComponent<Animator>();
        logoAnimator = logo.GetComponent<Animator>();
        playAnimator = playButton.GetComponent<Animator>();
        exitAnimator = exitButton.GetComponent<Animator>();
        introTextAnimator = introText.GetComponent<Animator>();
        cameraTargetAnimator = cameraTarget.GetComponent<Animator>();
    }

    public void StartFadeIn()
    {
        StartCoroutine(IntroFadeIn());
    }

    public void StartFadeOut()
    {
        StartCoroutine(IntroFadeOut());
    }

    IEnumerator IntroFadeIn()
    {
        yield return new WaitForSeconds(0.5f);

        // Fade out text
        yield return AnimateUIElement(introTextAnimator, "FadeOut", "Out");
        introText.SetActive(false);

        // Start camera pan
        cameraTargetAnimator.SetTrigger("MenuPan");

        // Fade in screen
        StartCoroutine(AnimateUIElementSkippable(screenAnimator, "FadeIn", "In", "In", "Fire1"));

        yield return new WaitForSeconds(1f);

        // Fade in logo and buttons
        StartCoroutine(AnimateUIElementSkippable(logoAnimator, "FadeIn", "In", "In", "Fire1"));
        StartCoroutine(AnimateUIElementSkippable(playAnimator, "FadeIn", "In", "In", "Fire1"));
        StartCoroutine(AnimateUIElementSkippable(exitAnimator, "FadeIn", "In", "In", "Fire1"));

        yield return new WaitForSeconds(0.5f);
        GetComponent<CanvasGroup>().interactable = true;
    }

    IEnumerator IntroFadeOut()
    {
        StartCoroutine(AnimateUIElement(logoAnimator, "FadeOut", "Out"));
        StartCoroutine(AnimateUIElement(playAnimator, "FadeOut", "Out"));
        yield return AnimateUIElement(exitAnimator, "FadeOut", "Out");

        logo.SetActive(false);
        playButton.SetActive(false);
        exitButton.SetActive(false);
    }

    IEnumerator AnimateUIElement(Animator animator, string startTrigger, string endStateName)
    {
        animator.SetTrigger(startTrigger);
        while (!animator.gameObject.activeSelf || !animator.GetCurrentAnimatorStateInfo(0).IsName(endStateName))
        {
            yield return null;
        }
        animator.ResetTrigger(startTrigger);

    }

    IEnumerator AnimateUIElementSkippable(Animator animator, string startTrigger, string endStateName,
        string skipTrigger, string skipButton)
    {
        if (animator.isActiveAndEnabled)
        {
            animator.SetTrigger(startTrigger);
            while (!animator.gameObject.activeSelf || !animator.GetCurrentAnimatorStateInfo(0).IsName(endStateName))
            {
                if (Input.GetButtonDown(skipButton))
                {
                    animator.SetTrigger(skipTrigger);
                    animator.ResetTrigger(skipTrigger);
                    break;
                }
                yield return null;
            }
            animator.ResetTrigger(startTrigger);

            yield return null;
        }
    }
}
