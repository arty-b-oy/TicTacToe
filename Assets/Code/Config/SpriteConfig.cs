using UnityEngine;

namespace Code.Config
{
    [CreateAssetMenu(menuName = "Config/SpriteConfig")]
    public class SpriteConfig : ScriptableObject
    {
        public Sprite zeroSprite;
        public Sprite crossSprite;
    }
}