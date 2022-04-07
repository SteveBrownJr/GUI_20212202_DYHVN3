namespace Game.Logic
{
    internal interface IGameControl
    {
        public void PlayerMoveLeft();
        public void PlayerMoveRight();
        public void PlayerJump();
        public void PlayerCrouch();
        public void PlayerMelee();
    }
}