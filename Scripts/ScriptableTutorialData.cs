using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Omnilatent.TutorialMaker
{
    [System.Serializable]
    public class TutorialData
    {
        [SerializeField] private string id;
        public List<ScriptableTutorialData> requireTutorials; //must see this tutorial first before this is displayed
        public GameObject displayObject; //tut object to be created
        public int repeatTimes = 1; //how many time tutorial repeat
        [TextArea]
        public string textDialog;
        public bool saveOnDone; //this is the last tutorial of one progress, save after done

        public string Id
        {
            get
            {
                if (string.IsNullOrEmpty(id))
                {
                    Debug.LogError("Tutorial data's ID is required");
                }
                return id;
            }
            set => id = value;
        }
    }

    [CreateAssetMenu(fileName = "Tutorial Data", menuName = "Omnilatent/TutorialMaker Data")]
    public class ScriptableTutorialData : ScriptableObject
    {
        public TutorialData tutorialData;

        private void OnValidate()
        {
            if (tutorialData.displayObject != null)
            {
                var tutDisplay = tutorialData.displayObject.GetComponent<ITutorialDisplay>();
                if (tutDisplay == null)
                {
                    Debug.LogError($"{name}'s displayObject doesn't have ITutorialDisplay component");
                }
            }
        }

        private void OnEnable()
        {
            if (string.IsNullOrEmpty(tutorialData.Id))
            {
                Debug.Log($"{name}'s data's ID has been set to default value");
                tutorialData.Id = name;
            }
        }
    }
}