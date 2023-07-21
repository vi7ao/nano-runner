using UnityEngine;

public class Singleton<T> : MonoBehaviour
    where T : Component
{
    private static T _instance;
    public static T Instance {
        get {
            if (_instance == null){
                var objs = FindObjectsOfType (typeof(T)) as T[];
                if (objs.Length > 0) {
                    _instance = objs[0];
                    if (objs.Length > 1){
                        Debug.LogError("Mais de um " + typeof(T).Name + " na cena po kkkkk.");
                    }
                }
                if (_instance == null){
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }
}
