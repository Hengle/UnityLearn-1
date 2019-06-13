using UnityEngine;

public class TabWindowDemo : MonoBehaviour
{
    private TabWindowComponent _tabWindowComponent;
    private readonly string[] _tabs = { "Tab0", "Tab1", "Tab2" };

    private void Start()
    {
        //_tabWindowComponent = UIFactory.Instance.GetUI<TabWindowComponent>("Common/TabWindow", transform);
        //_tabWindowComponent.transform.SetAsFirstSibling();


        _tabWindowComponent = transform.GetComponentInChildren<TabWindowComponent>();
        _tabWindowComponent.SetData(transform, _tabs, OnTabChange);
    }

    private void OnTabChange(int index)
    {
        switch (index)
        {
            case 0:
                //do something
                break;
            case 1:
                //do something
                break;
            case 2:
                //do something
                break;
        }

        Debug.Log(">>>index:" + index);
    }
}
