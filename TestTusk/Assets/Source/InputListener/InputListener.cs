using UnityEngine;
using VContainer;
using VContainer.Unity;

public class InputListener : ITickable
{
  private readonly PlayerController _playerController;
    
  [Inject]
  public InputListener(PlayerController playerController)
  {
    _playerController = playerController;
  }
    
  public void Tick()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      _playerController.Jump();
    }
  }
}