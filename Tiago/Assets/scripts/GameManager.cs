using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState
    {
        Iniciando,
        MenuPrincipal,
        Gameplay
    }

    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        SetState(GameState.Iniciando);
        LoadScene("splash");
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Cena carregada: {scene.name}");

        switch (scene.name)
        {
            case "splash":
                SetState(GameState.Iniciando);
                break;

            case "Menu":
                SetState(GameState.MenuPrincipal);
                break;

            case "GetStarted_Scene":
                SetState(GameState.Gameplay);
                break;
        }
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;
        Debug.Log($"Estado atual: {CurrentState}");
    }

    // Apenas o GameManager troca de cena
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Caso queira carregar de forma aditiva
    public void LoadSceneAdditive(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void SetupPlayerInput(PlayerInput playerInput)
    {
        Debug.Log($"Input atribuído ao jogador: {playerInput.name}");
    }
}