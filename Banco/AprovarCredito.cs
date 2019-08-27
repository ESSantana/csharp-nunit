namespace Banco
{
    public class AprovarCredito: IAprovarCredito
    {
        public bool VerificarRegularidadeCPF(string cpf)
        {
            return false;
        }
    }

    public interface IAprovarCredito
    {
        bool VerificarRegularidadeCPF(string cpf);
    }
}