using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Omnilatent.TutorialMaker
{
    public interface ITutorialDisplay
    {
        void Setup(TutorialData data, GameObject initObject = null);
        void OnDoneTutorial();
    }
}