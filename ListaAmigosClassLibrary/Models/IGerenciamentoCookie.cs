namespace ListaAmigosClassLibrary.Models
{
    public interface IGerenciamentoCookie
    {
        void Create(string nome, string sobrenome, string email, string data);
    }
}