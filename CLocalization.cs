using System;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Localization
{
    /// <summary>
    /// Basic structure for storing translation properties.
    /// </summary>
    [Serializable] public struct GTranslation
    {
        [Tooltip("The translation's identifier, for example: English, Swedish.")]
        public string identifier;

        [Tooltip("The translation's text asset (JSON Format in .txt).")]
        public TextAsset translation;
    }

    /// <summary>
    /// Basic translation script.
    /// </summary>
    public class CLocalization : MonoBehaviour
    {
        #region Structures
        [Serializable] public struct Config
        {
            [Tooltip("The current translation.")] public GTranslation currentTranslation;

            [Tooltip("An array of translations.")] public GTranslation[] translations;
        }
        #endregion
        #region Variables
        [SerializeField] private Config config;

        /// <summary>
        /// A private instance so we can access non-static functions and variables.
        /// </summary>
        private static CLocalization instance;
        #endregion

        /// <summary>
        /// Set the instance.
        /// </summary>
        private void Awake()
        {
            instance = this;
            var translations = config.translations;
            for (ushort i = 0; i < translations.Length; i++)
            {
                var translation = translations[i];
                if (translation.translation) continue;
                Debug.LogError($"Translation \"{translation.identifier}\" has no translation text asset!");
            }
        }

        /// <summary>
        /// Find a translation by it's identifier.
        /// </summary>
        /// <param name="identifier">The translation identifier (non-case sensitive)</param>
        /// <returns>The translation if found.</returns>
        private GTranslation FindTranslation(string identifier)
        {
            var translations = config.translations;
            var result = new GTranslation();
            for (ushort i = 0; i < translations.Length; i++)
            {
                var translation = translations[i];
                if (!string.Equals(translation.identifier, identifier,
                    StringComparison.CurrentCultureIgnoreCase)) continue;
                result = translation;
            }

            return result;
        }

        /// <summary>
        /// Read the full translation file.
        /// </summary>
        /// <param name="identifier">Language identifier.</param>
        /// <returns>The full content.</returns>
        private string ReadFull(string identifier) => FindTranslation(identifier).translation.text;

        /// <summary>
        /// Get the translation from a key.
        /// <para>The translation is automatically chosen from <see cref="config"/> -> currentTranslation.</para>
        /// </summary>
        /// <param name="key">The translation key.</param>
        /// <returns>The translated content.</returns>
        internal static string GetTranslation(string key)
        {
            var ins = instance;
            var jOBJ = JObject.Parse(ins.ReadFull(ins.config.currentTranslation.identifier));
            return (jOBJ[key] ?? key).ToString();
        }
    }
}
