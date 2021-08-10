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
        [SerializeField] TutorialData m_Data;
        public TutorialData GetData() => m_Data;
        public void SetData(TutorialData value) => m_Data = value;

        public bool checkOnStart = true; //set to false if you're going to chain tutorial
        [SerializeField] bool deactivateOnDone;
        [SerializeField] bool isRepeatTutorial; //if true, isDone variable won't be set on OnDoneTutorial

        [Tooltip("Begin this tutorial step when this step is completed")]
        [SerializeField] TutorialStep nextStep;

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
                if (TutorialManager.HasSeenTutorial(m_Data))
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
            if (!isDone && TutorialManager.CanShowTutorial(m_Data))
            {
                m_TutorialDisplay = Instantiate(m_Data.displayObject, transform).GetComponent<ITutorialDisplay>();
                TutorialManager.OnShowTutorial(m_Data, m_TutorialDisplay);
                //m_TutorialDisplay.transform.SetParent(transform.parent);
                m_TutorialDisplay.Setup(m_Data, gameObject);
                //isDone = false;
                //(m_Tut);
            }
        }

        public void CompleteStep()
        {
            if (!TutorialManager.HasSeenTutorial(m_Data))
            {
                TutorialManager.CompleteTutorial(m_Data);
            }
            isUnexpectedDestroy = false;
            onComplete?.Invoke();
        }
    }
}