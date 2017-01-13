using ControleLivraria2.Controller;
using ControleLivraria2.Controller.Implement;

namespace ControleLivraria2.Helpers
{
    public class ControllerFactory
    {
        public static ILivroController ObterLivroController()
        {
            return new LivroController();
        }
    }
}