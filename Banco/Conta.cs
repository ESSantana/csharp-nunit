using System;

namespace Banco
{
    public class Conta : IConta
    {
        private IAprovarCredito _aprovarCredito;

        public string cpf { get; set; }
        public int saldoEmConta { get; set; }
        public string numConta { get; set; }

        public Conta(string cpf, int saldoEmConta, string numConta, IAprovarCredito aprove)
        {
            this.cpf = cpf;
            this.saldoEmConta = saldoEmConta;   
            this.numConta = numConta;
            _aprovarCredito = aprove;
        }

        public bool consultarCredito(string cpf)
        {
            bool confirm = _aprovarCredito.VerificarRegularidadeCPF(cpf);
            return confirm;
        }

        public bool pedirEmprestimo(string cpf)
        {
            
            return false;
        }

        public int adicionarSaldo(string numConta, int saldo)
        {
            return 0;
        }
        
        public string VerificarTamanhoCPF(string cpf)
        {
            if( cpf.Length != 11)
            {
                throw new SystemException("CPF is incorrect!");
            } 
            return cpf;
        }


    }

    public interface IConta{
        bool consultarCredito(string cpf);
        bool pedirEmprestimo(string cpf);
        string VerificarTamanhoCPF(string cpf);
        int adicionarSaldo(string numConta, int saldo);

    }
}
