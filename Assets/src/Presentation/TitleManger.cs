using UnityEngine;
using TMPro;
using Src.Application;
using Src.Domain.ValueObjects;
using UnityEngine.SceneManagement;

public class TitleManger : MonoBehaviour
{
    public void Login()
    {
        if (_id == null) return;
        _root.Login.Login(_id,_name);
        SceneManager.LoadScene("InGame");
    }

    [SerializeField] private TMP_InputField _idText;
    [SerializeField] private TMP_InputField _nameText;
    private CompositionRoot _root;
    private PlayerId _id;
    private Name _name;
    private void Start()
    {
        _idText.onEndEdit.AddListener(OnIdChanged);
        _nameText.onEndEdit.AddListener(OnNameChanged);
        _root = FindAnyObjectByType<CompositionRoot>();
    }

    private void OnIdChanged(string input)
    {
        if (int.TryParse(input, out int result))
        {
            _id  = new PlayerId(result);
          
        }
    }

    private void OnNameChanged(string input)
    {
        _name = new Name(input);
    }

}
