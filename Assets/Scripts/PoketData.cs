using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class duckPoket
{
    public int DuckIntIndex;
    public string text;
}
public class PoketData : Singleton<PoketData>
{
    public List<duckPoket> poketList;

}
