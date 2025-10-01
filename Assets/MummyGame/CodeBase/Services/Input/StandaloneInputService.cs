using UnityEngine;

namespace MummyGame.CodeBase.Services.Input
{
    public class StandaloneInputService : InputService
    {
        public override Vector3 Axis => UnityAxis();
        
        private static Vector3 UnityAxis() => 
            new(UnityEngine.Input.GetAxis(Horizontal), 0f, UnityEngine.Input.GetAxis(Vertical));
    }
}