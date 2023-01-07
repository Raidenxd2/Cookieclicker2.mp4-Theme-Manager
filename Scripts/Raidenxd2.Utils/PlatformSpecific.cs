using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpecific : MonoBehaviour
{
    public GameObject[] AndroidOnly;
    public GameObject[] PCOnly;
    public GameObject[] DevModeOnly;

    void Start()
    {
        if (!Application.isMobilePlatform)
        {
            foreach (var item in AndroidOnly)
            {
                item.SetActive(false);
            }
        }
        if (Application.isMobilePlatform)
        {
            foreach (var item in PCOnly)
            {
                item.SetActive(false);
            }
        }
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            foreach (var item in DevModeOnly)
            {
                item.SetActive(true);
            }
            return;
        }
#if DEVELOPMENT_BUILD
        foreach (var item in DevModeOnly)
        {
            item.SetActive(true);
        }
#endif
    }
}
