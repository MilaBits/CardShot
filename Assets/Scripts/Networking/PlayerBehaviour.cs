using UnityEngine;

namespace Networking {
    public class PlayerBehaviour : Bolt.EntityBehaviour<IPlayerState> {
        private float translation;
        private float straffe;

        private CharacterInput characterInput;
        
        public override void Attached() {
            // Your code here...
            
            characterInput = new CharacterInput(this);
        }

        public override void SimulateOwner() {
            
            characterInput.Move();
            
        }
    }
}