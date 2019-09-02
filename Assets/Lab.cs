using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lab : MonoBehaviour, IPointerEnterHandler
{

    private void Start()
    {
    }

    public void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {

        }
    }

    [ContextMenu("Play")]
    private void Play()
    {
        Debug.Log("do lua ");
        // do lua
    }


    public async static void GetInfoAsync()
    {
        await GetData();
        await GetData<int>(1);
        Debug.Log(222);
    }


    static Task GetData()
    {
        Debug.Log(000);
        return null;
    }

    static Task<T> GetData<T>(int a)
    {
        Debug.Log(111);
        return null;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }


    public async Task SetAsync()
    {
        Debug.Log(00000000000000);


        await Task.Delay(4 * 1000);

        Debug.Log(1111);
    }


    /// <summary>
    /// 朗母达表达式排序
    /// </summary>
    private void LongmudaLab()
    {
        var list = new List<Student>
            {
                new Student (10,160),
                new Student (20,170),
                new Student (20,150)
            };

        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i].ToString());
        }

        //按照年龄排序
        //如果年龄一致的话则按照身高排序
        list.Sort((item1, item2) =>
        {
            if (item1.Age == item2.Age)
            {
                return item1.Height.CompareTo(item2.Height);
            }
            return item1.Age.CompareTo(item2.Age);
        });

        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i].ToString());
        }
    }

    private class Student
    {
        public int Age;
        public int Height;

        public Student(int age, int height)
        {
            Age = age;
            Height = height;
        }

        public override string ToString()
        {
            return ("Age:" + Age + " Height:" + Height);
        }
    }
}
