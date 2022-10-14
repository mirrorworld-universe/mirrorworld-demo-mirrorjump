using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPanel : MonoSingleton<LoadingPanel>
{
    [SerializeField] private GameObject loadingPanel;

    public void SetLoadingPanelEnable(bool isEnable)
    {
        loadingPanel.SetActive(isEnable);
    }
}
