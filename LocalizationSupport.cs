using TMPro;
using UnityEngine;

namespace Localization
{
    /// <summary>
    /// Add support for translating text which relies on <see cref="TextMeshProUGUI"/>.
    /// </summary>
    public class LocalizationSupport : MonoBehaviour
    {
        #region Structures
        private struct Cache
        {
            /// <summary>
            /// The text to be translated.
            /// </summary>
            public TextMeshProUGUI text;
        }
        #endregion
        #region Variables
        private Cache cache;
        #endregion

        /// <summary>
        /// Translate the text.
        /// </summary>
        private void Start()
        {
            var tmp = cache.text = GetComponent<TextMeshProUGUI>();
            if (!tmp)
            {
                Debug.LogError($"A localization text is missing on object: {transform.parent.name}");
                return;
            }

            var cText = tmp.text;
            tmp.text = cText.Replace(cText, CLocalization.GetTranslation(cText));
        }
    }
}
