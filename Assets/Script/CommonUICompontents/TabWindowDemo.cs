using System.Collections.Generic;
using UnityEngine;

public class TabWindowDemo : MonoBehaviour
{
    private TabWindowComponent _tabWindowComponent;
    private List<string> _tabNameList;

    private void Start()
    {
        _tabWindowComponent = UIFactory.Instance.GetUI<TabWindowComponent>("Common/TabWindowCompontent/TabWindow", transform);
        _tabWindowComponent.transform.SetAsFirstSibling();

        //_tabWindowComponent = transform.GetComponentInChildren<TabWindowComponent>();
        _tabNameList = new List<string>()
        {
            "1",
            "2",
            "3"
        };
        //_tabWindowComponent.SetData(transform, _tabNameList, OnTabChange);
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
