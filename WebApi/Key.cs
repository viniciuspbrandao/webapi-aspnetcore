namespace WebApi
{
    public class Key
    {
        //O algoritmo HmacSha256 exige uma chave com no mínimo 256 bits (32 bytes).
        //Cada caractere ASCII representa 1 byte, então precisamos de uma string com pelo menos 32 caracteres.
        public static string Secret = "S3nh4Muit0S3gur@ECompr1d4!!123456";
    }
}
