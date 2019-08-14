using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIComponentController : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.RegistGameObject(name, gameObject);
    }

    public void AddButtonListenter(UnityAction unityAction)
    {
        if (unityAction != null)
        {
            Button button = transform.GetComponent<Button>();
            button.onClick.AddListener(unityAction);
        }
    }

    public void RemoveButtonListenter(UnityAction unityAction)
    {
        if (unityAction != null)
        {
            Button button = transform.GetComponent<Button>();
            button.onClick.RemoveListener(unityAction);
        }
    }

    public void SetImageSprite(Sprite sprite)
    {
        if (sprite != null)
        {
            Image image = transform.GetComponent<Image>();
            image.sprite = sprite;
        }
    }
}
