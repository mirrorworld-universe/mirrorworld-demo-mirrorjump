using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VersionCheckDialog : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI titleText;
    [SerializeField] protected TextMeshProUGUI messageLabel;
    [SerializeField] protected Button confirmButton;
    [SerializeField] protected Button cancelButton;

    public event System.Action confirmClicked;
    public event System.Action cancelClicked;

    private void Awake()
    {
        // 默认只展示一个按钮
        if(cancelButton) cancelButton.gameObject.SetActive(false);
    }

    public void Start()
    {

        if (confirmButton) confirmButton.onClick.AddListener(OnConfirmClicked);
        if (cancelButton) cancelButton.onClick.AddListener(OnCancelClicked);
    }

    // 启用第二个按钮
    public void EnableCancelButton(string cancelButtonText = "")
    {
        cancelButton.gameObject.SetActive(true);

        if(cancelButtonText != "")
        {
            cancelButton.GetComponentInChildren<TextMeshProUGUI>().text = cancelButtonText;
        }
    }

    public virtual void displayMessage(string title, string msg, string confirmButtonText = "")
    {
        titleText.text = title;
        messageLabel.text = msg;
        this.gameObject.SetActive(true);

        if(confirmButtonText != "")
        {
            confirmButton.GetComponentInChildren<TextMeshProUGUI>().text = confirmButtonText;
        }
    }

    public void OnConfirmClicked()
    {
        this.gameObject.SetActive(false);
        confirmClicked?.Invoke();
    }

    public void OnCancelClicked()
    {
        cancelClicked?.Invoke();
    }
}
