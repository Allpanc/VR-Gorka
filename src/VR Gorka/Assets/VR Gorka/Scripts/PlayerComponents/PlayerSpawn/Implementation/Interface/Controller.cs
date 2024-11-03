namespace VrGorka.PlayerSpawn.Interface
{
    class Controller : IController
    {
        readonly Logic.PlayerFactory _playerFactory;

        public Controller(Logic.PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }
        
        public IPlayer SpawnPlayer()
        {
            return _playerFactory.Create();
        }
    }
}