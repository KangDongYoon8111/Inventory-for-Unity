using UnityEngine;

public class InputController : MonoBehaviour
{
    public string moveAxisName = "Horizontal";

    public float move { get; private set; }

    void Update()
    {
        move = Input.GetAxisRaw(moveAxisName);
    }
}
