using UnityEngine;
using TMPro;
using Src.Application;
using Src.Domain.ValueObjects;
using UnityEngine.SceneManagement;
using System;

public class TitleManger : MonoBehaviour
{

    //IDと名前自体にこのチェックをもたせるかも
    public void Login()
    {
        if (!int.TryParse(_idText.text, out int idValue))
        {
            Debug.LogError("IDは数値で入力してください。");
            return;
        }

        if (string.IsNullOrWhiteSpace(_nameText.text))
        {
            Debug.LogError("名前を入力してください。");
            return;
        }

        try
        {
            _id = new PlayerId(idValue);
            _name = new Name(_nameText.text);
        }
        catch (ArgumentException ex)
        {
            Debug.LogError(ex.Message);
            return;
        }

        _root.Login.Login(_id, _name);
        SceneManager.LoadScene("InGame");
    }


    [SerializeField] private TMP_InputField _idText;
    [SerializeField] private TMP_InputField _nameText;
    private CompositionRoot _root;
    private PlayerId _id;
    private Name _name;
    private void Start()
    {
        _root = FindAnyObjectByType<CompositionRoot>();
    }

}
