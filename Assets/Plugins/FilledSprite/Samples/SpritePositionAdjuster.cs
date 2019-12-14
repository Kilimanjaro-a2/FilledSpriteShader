// Retrieved from:
// https://github.com/Kilimanjaro-a2/SpritePositionAdjuster/blob/master/Assets/Plugins/SpritePositionAdjuster/SpritePositionAdjuster.cs
using UnityEngine;

namespace KiliWare
{
    public class SpritePositionAdjuster : MonoBehaviour
    {
        public float OriginalScreenHeight = 0f;
        public bool KeepsPositionUpdated = true;
        protected Vector2 startPosition;
        protected Vector2 startScale;
        protected int previousScreenWidth;
        protected int previousScreenHeight;

        #if UNITY_EDITOR
            public bool showsDebugLog = true;
        #endif

        protected void Awake()
        {
            startScale = transform.localScale;
            startPosition = transform.position - Camera.main.transform.position;

            #if UNITY_EDITOR
                if (showsDebugLog)
                {
                    Debug.Log("Current screen height is: " + Screen.height + ". If you want to preserve current scale and position of this sprites, set OriginalScreenHeight property " + Screen.height + " and restart the scene to check whether it works correctly.");
                }
            #endif

            previousScreenWidth = Screen.width;
            previousScreenHeight = Screen.height;

            adjustSpritePosition();
        }

        public void adjustSpritePosition()
        {
            float ajustedHeight = OriginalScreenHeight / Screen.height;

            transform.localScale = new Vector2(startScale.x, startScale.y) * ajustedHeight;

            Vector2 cameraPos = Camera.main.transform.position;
            transform.position = startPosition * ajustedHeight + cameraPos;
        }

        // When you checkes "KeepsPositionUpdated",
        // the sprite position's change follows the change of window size. 
        protected void Update()
        {
            if (KeepsPositionUpdated && isScreenSizeChanged())
            {
                adjustSpritePosition();
                previousScreenWidth = Screen.width;
                previousScreenHeight = Screen.height;
            }
        }

        protected bool isScreenSizeChanged()
        {
            return previousScreenHeight != Screen.height || previousScreenWidth != Screen.width;
        }
    }
}

