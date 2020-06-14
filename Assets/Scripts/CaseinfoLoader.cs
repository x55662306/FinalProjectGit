using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class CaseinfoLoader : MonoBehaviour
{
    [Serializable]
    public class CaseInfo
    {
        public int id;
        public string caseType;
        public int reward;
        public int toxicity;
        public CaseInfo(int id, string caseType, int reward, int toxicity)
        {
            this.id = id;
            this.caseType = caseType;
            this.reward = reward;
            this.toxicity = toxicity;
        }

        public void print()
        {
            Debug.Log(caseType);
        }
    }

    [Serializable]
    public class Serialization<T>
    {
        [SerializeField]
        List<T> target;
        public List<T> ToList() { return target; }

        public Serialization(List<T> target)
        {
            this.target = target;
        }
    }

    // Dictionary<TKey, TValue>
    [Serializable]
    public class Serialization<TKey, TValue> : ISerializationCallbackReceiver
    {
        [SerializeField]
        List<TKey> keys;
        [SerializeField]
        List<TValue> values;

        Dictionary<TKey, TValue> target;
        public Dictionary<TKey, TValue> ToDictionary() { return target; }

        public Serialization(Dictionary<TKey, TValue> target)
        {
            this.target = target;
        }

        public void OnBeforeSerialize()
        {
            keys = new List<TKey>(target.Keys);
            values = new List<TValue>(target.Values);
        }

        public void OnAfterDeserialize()
        {
            var count = Math.Min(keys.Count, values.Count);
            target = new Dictionary<TKey, TValue>(count);
            for (var i = 0; i < count; ++i)
            {
                target.Add(keys[i], values[i]);
            }
        }
    }

    static public List<CaseInfo> caseInfoList;

    private void Awake()
    {
        string filePath = Application.dataPath + "/StreamingAssets";
        string nameAndPath = filePath + "/" + "CaseInfo.json";//存檔的位置加檔名
        string jsonInfo = File.ReadAllText(nameAndPath);
        caseInfoList = JsonUtility.FromJson<Serialization<CaseInfo>>(jsonInfo).ToList();
    }
}
