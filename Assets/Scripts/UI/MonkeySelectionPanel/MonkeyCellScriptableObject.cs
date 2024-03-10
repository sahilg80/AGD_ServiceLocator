using UnityEngine;
using ServiceLocator.Player;

namespace ServiceLocator.UI
{
    [CreateAssetMenu(fileName = "MonkeyCellScriptableObject", menuName = "ScriptableObjects/MonkeyCellScriptableObject")]
    public class MonkeyCellScriptableObject : ScriptableObject
    {
        public MonkeyType Type;
        public string Name;
        public Sprite Sprite;
        public int Cost;
        public bool Lockable;
        public int CostToUnlock;
    }
}