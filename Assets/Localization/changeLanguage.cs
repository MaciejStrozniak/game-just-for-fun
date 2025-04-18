using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class changeLanguage : MonoBehaviour
{
    public int localeNumberOnButton = 1;

    void Start()
    {
        StartCoroutine(SetLocaleCoroutine(localeNumberOnButton));
    }

    IEnumerator SetLocaleCoroutine(int _localeID) // for Polish set 2
    {
        yield return LocalizationSettings.InitializationOperation;

        if(LocalizationSettings.InitializationOperation.IsDone)
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
            Debug.Log("Localization: " + LocalizationSettings.InitializationOperation.IsDone);
        }
    }

    public void ChangeLocaleOnButtonPressed()
    {             
        localeNumberOnButton ++;

        if(localeNumberOnButton < LocalizationSettings.AvailableLocales.Locales.Count)
        {
            Debug.Log("Button pressed");
            StartCoroutine(SetLocaleCoroutine(localeNumberOnButton));
        }
        else if(localeNumberOnButton >= LocalizationSettings.AvailableLocales.Locales.Count)
        {
            localeNumberOnButton = 0;
            StartCoroutine(SetLocaleCoroutine(localeNumberOnButton));
        }
    }
}