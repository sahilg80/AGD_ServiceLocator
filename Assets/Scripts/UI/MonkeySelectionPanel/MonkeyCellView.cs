using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ServiceLocator.UI
{
    public class MonkeyCellView : MonoBehaviour
    {
        private MonkeyCellController controller;

        [SerializeField] private MonkeyImageHandler monkeyImageHandler;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI costText;
        [SerializeField] private TextMeshProUGUI costToUnlockText;
        [SerializeField] private GameObject lockedStateObject;

        public void SetController(MonkeyCellController controllerToSet) => controller = controllerToSet;

        public void ConfigureCellUI(Sprite spriteToSet, string nameToSet, int costToSet, int costToUnlock, bool status)
        {
            monkeyImageHandler.ConfigureImageHandler(spriteToSet, controller);
            nameText.SetText(nameToSet);
            costText.SetText(costToSet.ToString());

            nameText.transform.gameObject.SetActive(!status);
            costText.transform.gameObject.SetActive(!status);
            lockedStateObject.SetActive(status);
            costToUnlockText.transform.gameObject.SetActive(status);
            costToUnlockText.SetText(costToUnlock.ToString());

        }

        public void OnClickMonkey()
        {
            bool status = monkeyImageHandler.MonkeyUnlockStatus();
            nameText.transform.gameObject.SetActive(status);
            costText.transform.gameObject.SetActive(status);
            lockedStateObject.SetActive(!status);
            costToUnlockText.transform.gameObject.SetActive(!status);
        }

    }
}