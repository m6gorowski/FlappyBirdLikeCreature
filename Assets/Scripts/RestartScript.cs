using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    [SerializeField] private Transform _box;
    [SerializeField] private CanvasGroup _background;

    private void OnEnable()
    {
        _background.alpha = 0;
        _background.LeanAlpha(1, 0.5f);


        _box.localPosition = new Vector2(0, -Screen.height);
        _box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
