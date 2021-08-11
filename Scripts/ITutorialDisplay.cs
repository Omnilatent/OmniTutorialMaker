using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Omnilatent.TutorialMaker
{
    public interface ITutorialDisplay
    {
        Action callbackToStepObject { get; set; }
        void Setup(TutorialData data, GameObject initObject = null);

        /// <summary>
        /// Call when the display object is clicked.
        /// </summary>
        /// <param name="callbackToStepObj">If true, click on this object will callback step complete to the TutorialStep who created this display</param>
        void OnDisplayClicked(bool callbackToStepObj);
    }
}