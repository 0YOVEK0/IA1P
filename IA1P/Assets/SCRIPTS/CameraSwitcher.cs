using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera playerCamera;    // Cámara del jugador
    public Camera spectatorCamera; // Cámara de espectador
    private bool isSpectatorMode = false;

    void Start()
    {
        // Activa la cámara del jugador al inicio
        playerCamera.enabled = true;
        spectatorCamera.enabled = false;
    }

    void Update()
    {
        // Cambiar de cámara al presionar la tecla X
        if (Input.GetKeyDown(KeyCode.X))
        {
            ToggleCameraMode();
        }
    }

    void ToggleCameraMode()
    {
        isSpectatorMode = !isSpectatorMode;

        if (isSpectatorMode)
        {
            // Cambiar a la cámara de espectador
            playerCamera.enabled = false;
            spectatorCamera.enabled = true;
        }
        else
        {
            // Cambiar de vuelta a la cámara del jugador
            playerCamera.enabled = true;
            spectatorCamera.enabled = false;
        }
    }
}
