using UnityEngine;

namespace MummyGame.CodeBase.Services.Input
{
    public class MobileInputService : InputService
    {
        public override Vector3 Axis => MobileInputAxis();
        
        protected static Vector3 MobileInputAxis()
        {
            // пока заглушка с UnityEngine.Input
            return new(UnityEngine.Input.GetAxis(Horizontal), 0f, UnityEngine.Input.GetAxis(Vertical));
        }
    }
}