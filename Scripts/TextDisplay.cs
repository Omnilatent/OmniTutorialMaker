using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Omnilatent.TutorialMaker
{
    public class TextDisplay : MonoBehaviour, ITutorialDisplay
    {
        [SerializeField] protected TMP_Text textDialog;
        [SerializeField] Button dialogueButton;
        [SerializeField] protected bool destroyOnDone = true;
        [HideInInspector] public TutorialData m_Data;

        public Action callbackToStepObject { get; set; }

        protected bool isUnexpectedDestroy = true;

        protected virtual void Start()
        {
            if (dialogueButton != null)
            {
                dialogueButton.onClick.AddListener(() =>
                {
                    OnDisplayClicked(true);
                });
            }
        }

        public virtual void Setup(TutorialData data, GameObject initObject = null)
        {
            m_Data = data;
            if (textDialog != null) { textDialog.text = data.textDialog; }
        }

        public virtual Transform GetTransform() { return transform; }

        void SetParent(Transform targetTransform)
        {
            transform.SetParent(targetTransform);
        }

        public virtual void OnDisplayClicked(bool callbackToStepObj)
        {
            //if (!TutorialManager.HasSeenTutorial(m_Data))
            //{
            isUnexpectedDestroy = false;
            //TutorialManager.CompleteTutorial(m_Data);
            if (callbackToStepObj)
                callbackToStepObject?.Invoke();
            if (destroyOnDone) Destroy(gameObject);
            //}
        }


        private void OnDestroy()
        {
            if (isUnexpectedDestroy) TutorialManager.OnTutorialEndUnexpected();
        }
    }
}