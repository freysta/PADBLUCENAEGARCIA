using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Excecoes
{
    public class ErroServicoException : Exception
    {
        private readonly Func<ControllerBase, IActionResult> _resultado;

        public ErroServicoException(string mensagem, Func<ControllerBase, IActionResult> resultado) : base(mensagem) 
        {
            _resultado = resultado;
        }

        public IActionResult ParaResultadoAcao(ControllerBase controller)
        {
            return _resultado(controller);
        }
    }
}
