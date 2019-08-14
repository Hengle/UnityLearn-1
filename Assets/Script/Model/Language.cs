using System.Collections.Generic;
using System;

[Serializable]
public class LanguageList
{
    public List<LanguageItem> languages;
}

[Serializable]
public class LanguageItem
{
    public string key;
    public string value;
}

