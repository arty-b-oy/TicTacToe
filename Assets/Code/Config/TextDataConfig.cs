using UnityEngine;

namespace Code.Config
{
    [CreateAssetMenu(menuName = "Config/TextDataConfig")]

    public class TextDataConfig : ScriptableObject
    {
        public string nameSaveFile;
        public string textMoveX;
        public string textMoveO;
        public string textWinX;
        public string textWinO;
        public string textDraw;
    }
}