﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData : MonoBehaviour
{


    void Start()
    {
        string path = @"C:\Users\admin\Desktop";
        WriteTextToLaocal(path, "图集的引用.txt", "123");
    }



    /// <summary>
    /// 写入文本到本地
    /// </summary>
    /// <param name="path">文本的保存路径</param>
    /// <param name="fileName">文件的名字</param>
    /// <param name="content">写入内容</param>
    private void WriteTextToLaocal(string path, string fileName, string content)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        FileInfo fileInfo = new FileInfo(path + "/" + fileName);
        StreamWriter streamWriter = fileInfo.CreateText();
        streamWriter.WriteLine(content);
        streamWriter.Close();
        streamWriter.Dispose();
    }

}

