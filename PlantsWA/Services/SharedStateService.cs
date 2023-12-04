namespace Plants.WA.Services
{
    
    public class SharedStateService
    {
        public event Action<bool> ValorActualizado;

        private bool _logged = false;

        public bool ObtenerValor()
        {
            return _logged;
        }

        public void ActualizarValor(bool nuevoValor)
        {
            _logged = nuevoValor;
            ValorActualizado?.Invoke(_logged);
        }
    }

}
