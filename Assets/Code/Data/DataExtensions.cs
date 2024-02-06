
using UnityEngine;

namespace Code.Data
{
    public static class DataExtensions
    {
        public static T ToDeseralized<T>(this string json) =>
            JsonUtility.FromJson<T>(json);

        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj);
    }
}
