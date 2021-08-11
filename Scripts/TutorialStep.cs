using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Omnilatent.TutorialMaker
{
    /// <summary>
    /// Handle call to and from TutorialManager, initialize Tutorial Display items.
    /// </summary>
    public class TutorialStep : MonoBehaviour
    {
        //You can either store tutorial data in this component or use a scriptable object

        [SerializeField] TutorialData m_Data;

        [Tooltip("If set, scriptable data will be used and m_Data field will be ignored")]
        [SerializeField] ScriptableTutorialData scriptableData;
        public TutorialData GetData()
        {
            if (scriptableData != null)
            {
                return scriptableData.tutorialData;
            }
            return m_Data;
        }
        public void SetData(TutorialData value) => m_Data = value;

        [SerializeField] Transform displayContainer; //display object will set parent to this transform

        [Tooltip("Begin this tutorial step when this step is completed")]
        [SerializeField] TutorialStep nextStep;

        public bool checkOnStart = true; //set to false if you're going to chain tutorial
        [SerializeField] bool deactivateOnDone;
        [SerializeField] bool isRepeatTutorial; //if true, isDone variable won't be set on OnDoneTutorial

        [SerializeField] UnityEvent onBegin;
        [SerializeField] UnityEvent onComplete;

        ITutorialDisplay m_TutorialDisplay;
        public ITutorialDisplay GetTutorialDisplay() => m_TutorialDisplay;

        bool isDone;
        public bool IsDone { get => isDone; set => isDone = value; }
        bool isUnexpectedDestroy;

        void Start()
        {
            if (!isDone)
            {
                if (TutorialManager.HasSeenTutorial(GetData()))
                {
                    isDone = true;
                    if (deactivateOnDone)
                    {
                        gameObject.SetActive(false);
                    }
                    return;
                }
            }
            if (checkOnStart)
            {
                Init();
            }
        }

        public void Init()
        {
            if (!isDone && TutorialManager.CanShowTutorial(GetData()))
            {
                m_TutorialDisplay = Instantiate(GetData().displayObject, displayContainer).GetComponent<ITutorialDisplay>();
                TutorialManager.OnShowTutorial(GetData(), m_TutorialDisplay);
                //m_TutorialDisplay.transform.SetParent(transform.parent);
                m_TutorialDisplay.Setup(GetData(), gameObject);
                m_TutorialDisplay.callbackToStepObject += CompleteStep;
                //isDone = false;
                //(m_Tut);
                onBegin?.Invoke();
            }
        }

        internal void CompleteStep()
        {
            if (!TutorialManager.HasSeenTutorial(GetData()))
            {
                TutorialManager.CompleteTutorial(GetData());
            }
            isUnexpectedDestroy = false;
            onComplete?.Invoke();
            nextStep?.Init();
        }

        public void CompleteStepAndClearDisplay()
        {
            m_TutorialDisplay.OnDisplayClicked(false);
            CompleteStep();
        }

        private void Reset()
        {
            displayContainer = transform;
        }
    }
}