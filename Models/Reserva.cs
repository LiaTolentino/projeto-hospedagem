namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        /// <summary>
        /// Verifica se a capacidade é maior ou igual ao número de hóspedes sendo recebido
        /// </summary>
        /// <param name="hospedes"></param>
        /// <exception cref="Exception"></exception>
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
                foreach (Pessoa p in Hospedes)
                {
                    Console.WriteLine($"Hóspede {p.NomeCompleto} cadastrado com sucesso");
                }
            }
            else
            {
                throw new Exception($"Reserva não permitida, pois o número de hóspedes informado ({hospedes.Count}) é maior que a capacidade da suíte");
            }
        }

        /// <summary>
        /// Realiza o cadastro da suíte
        /// </summary>
        /// <param name="suite"></param>
        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;

            Console.WriteLine($"\nSuíte {suite.TipoSuite} cadastrada com sucesso\n");
        }

        /// <summary>
        /// Retorna a quantidade de hóspedes
        /// </summary>
        /// <returns></returns>
        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        /// <summary>
        /// Retorna o valor da diária baseado na quantidade de dias reservados x suite.valorDiaria
        /// </summary>
        /// <returns></returns>
        public decimal CalcularValorDiaria()
        {
            decimal valor;

            valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                Console.WriteLine($"Parabéns, você ganhou um desconto de 10% na sua reserva");
                valor *= 0.90M;
            }
            return valor;
        }
    }
}