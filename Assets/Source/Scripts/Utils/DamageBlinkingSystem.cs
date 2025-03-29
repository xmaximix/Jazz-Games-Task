using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Scripts.Utils
{
    public class DamageBlinkingSystem : MonoBehaviour
    {
        private float blinkDuration = 0.1f; 
        private float intensity = .9f; 
        private List<SpriteRenderer> allSprites;
        private List<Color> originalColors; // To store the original sprite colors

        public void Initialize()
        {
            var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
            allSprites = new List<SpriteRenderer>(spriteRenderers);

            originalColors = new List<Color>(); // Initialize list for original colors

            if (TryGetComponent(out SpriteRenderer spriteRenderer))
            {
                allSprites.Add(spriteRenderer);
            }
            foreach (var renderer in allSprites)
            {
                if (renderer != null)
                {
                    originalColors.Add(renderer.color);
                }
            }
        }
        
        private IEnumerator DamageBlink()
        {
            float elapsedTime = 0f;

            SetBlinkColor(Color.white);

            while (elapsedTime < blinkDuration)
            {
                float currentAlpha = Mathf.Lerp(intensity, .3f, elapsedTime / blinkDuration);
                SetBlinkColor(new Color(1f, 1f, 1f, currentAlpha)); 

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            SetOriginalColor();
        }

        private void SetBlinkColor(Color color)
        {
            for (int i = 0; i < allSprites.Count; i++)
            {
                if (allSprites[i] != null)
                {
                    allSprites[i].color = color;
                }
            }
        }

        private void SetOriginalColor()
        {
            for (int i = 0; i < allSprites.Count; i++)
            {
                if (allSprites[i] != null)
                {
                    allSprites[i].color = originalColors[i];
                }
            }
        }

        public void RepeatedBlink(int numRepeats, float blinkTime)
        {
            StartCoroutine(RepeatedBlinkCoroutine(numRepeats, blinkTime));
        }

        private IEnumerator RepeatedBlinkCoroutine(int numRepeats, float blinkTime)
        {
            for (int i = 0; i < numRepeats; i++)
            {
                yield return DamageBlink();
                yield return new WaitForSeconds(blinkTime);
            }
        }
    }
}
