﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.Components.Settings;
using Polyglot;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using BeatTogether.Model;

namespace BeatTogether.UI
{
    public class UiFactory
    {
        internal static ListSetting CreateServerSelectionView(MultiplayerModeSelectionViewController multiplayerView)
        {
            var parent = multiplayerView.gameObject.transform;
            FormattedFloatListSettingsValueController baseSetting = MonoBehaviour.Instantiate(Resources.FindObjectsOfTypeAll<FormattedFloatListSettingsValueController>().First(x => (x.name == "VRRenderingScale")), parent, false);
            baseSetting.name = "BSMLIncDecSetting";

            GameObject gameObject = baseSetting.gameObject;
            MonoBehaviour.Destroy(baseSetting);
            gameObject.SetActive(false);

            ListSetting serverSelection = gameObject.AddComponent<ListSetting>();
            gameObject.transform.position += new Vector3(0.0f, 0.15f, 0.0f);
            gameObject.transform.GetChild(1).position += new Vector3(-1.0f, 0.0f, 0.0f);

            serverSelection.text = gameObject.transform.GetChild(1).GetComponentsInChildren<TextMeshProUGUI>().First();
            serverSelection.text.richText = true;
            serverSelection.decButton = gameObject.transform.GetChild(1).GetComponentsInChildren<Button>().First();
            serverSelection.incButton = gameObject.transform.GetChild(1).GetComponentsInChildren<Button>().Last();
            (gameObject.transform.GetChild(1) as RectTransform).sizeDelta = new Vector2(60, 0);
            serverSelection.text.overflowMode = TextOverflowModes.Ellipsis;

            new ServerSelectionController(serverSelection, multiplayerView);

            TextMeshProUGUI text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            text.transform.position += new Vector3(1.2f, 0.0f, 0.0f);
            text.SetText("Playing on");
            text.richText = true;

            gameObject.GetComponent<LayoutElement>().preferredWidth = 90;
            gameObject.SetActive(true);

            return serverSelection;
        }
    }
}
