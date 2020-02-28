namespace TodoApi.Models
{
    public class Romano
    {
        public int Valor { get; private set; }
        public string Simbolo { get; private set; }
        public Romano (int valor, string simbolo)
        {
            Valor = valor;
            Simbolo = simbolo;
        }
    }
}