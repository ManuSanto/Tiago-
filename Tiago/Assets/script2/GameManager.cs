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

    public GameState currentState;

    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SetState(GameState.Iniciando);
        {
            SetState(GameState.Iniciando);
            LoadScene("splash");
        }
    }

    public void SetState(GameState newState)
    {
        currentState = newState;
        Debug.Log("Estado atual: " + currentState);
    }

    // Controle de cenas (SÓ o GameManager pode fazer isso)
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

        // Atualiza estado baseado na cena
        if (sceneName == "MenuPrincipal")
            SetState(GameState.MenuPrincipal);
        else if (sceneName == "GetStarted_Scene")
            SetState(GameState.Gameplay);
    }

    // Input allocation (simples)
    public void SetupPlayerInput(PlayerInput playerInput)
    {
        Debug.Log("Input atribuído ao jogador: " + playerInput.name);
    }

   
}