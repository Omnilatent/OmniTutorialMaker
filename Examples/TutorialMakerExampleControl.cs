using Omnilatent.TutorialMaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Omnilatent.TutorialMaker.Example
{
    public class TutorialMakerExampleControl : MonoBehaviour
    {
        public void ResetTutorialProgress()
        {
            Omnilatent.TutorialMaker.TutorialManager.ResetData();
            ReloadScene();
        }

        public void ReloadScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("1+2.TM_BasicSteps");
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
}