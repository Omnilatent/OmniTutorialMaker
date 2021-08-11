using Omnilatent.TutorialMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMakerExampleControl : MonoBehaviour
{
    public void ResetTutorialProgress()
    {
        Omnilatent.TutorialMaker.TutorialManager.ResetData();
        ReloadScene();
    }

    public void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("ExTutorial");
    }

    [SerializeField] TutorialStep[] tutSteps;

    public void OnRedButtonClick()
    {
        tutSteps[0].CompleteStepAndClearDisplay();
    }

    public void OnBlueButtonClick()
    {
        tutSteps[2].CompleteStepAndClearDisplay();
    }

    public void OnYellowButtonClick()
    {
        tutSteps[1].CompleteStepAndClearDisplay();
    }
}
