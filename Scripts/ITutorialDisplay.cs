using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Omnilatent.TutorialMaker
{
    public interface ITutorialDisplay
    {
        Action onComplete { get; set; }
        void Setup(TutorialData data, GameObject initObject = null);
        void CompleteTutorial();
    }
}