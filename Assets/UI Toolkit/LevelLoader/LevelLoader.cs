using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace UI_Toolkit.LevelLoader
{
    [RequireComponent(typeof(UIDocument))]
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private string[] sceneNames;

        private void Start()
        {
            var uiDocument = GetComponent<UIDocument>();
            var root = uiDocument.rootVisualElement;

            for (var i = 0; i < sceneNames.Length; i++)
            {
                var level = root.Q<Button>("level" + i);
                var currentIndex = i;
                level.clickable.clicked += () => SceneManager.LoadScene(sceneNames[currentIndex]);
            }
        }
    }
}