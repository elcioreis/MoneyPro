namespace Modelos
{
    public class Tipo
    {
        public enum Conta
        {
            Banco,
            Poupanca,
            Cartao,
            Investimento,
            CDB,
            Outras
        }

        public enum Legenda
        {
            Normal,
            Origem,
            Destino,
            Investimento,
            Despesas
        }

        public enum ClassificacaoRisco
        {
            Baixo = 1,
            MedioBaixo = 2,
            Medio = 3,
            MedioAlto = 4,
            Alto = 5
        }

        public enum CorRisco
        {
            Baixo = 0x4285F4,           // Azul
            MedioBaixo = 0x34A853,      // Verde
            Medio = 0xFFE068,           // Amarelo
            MedioAlto = 0xED822F,       // Laranja
            Alto = 0xEA4335             // Vermelho
        }

        public enum TipoConsultaInvestimentoVariacao
        {
            VariacaoDiaria,
            AcumuladoDiario,
            VariacaoMensal,
            AcumuladoMensal,
            CompletoMensal
        }

        public enum TipoConciliacao
        {
            NaoConciliado = ' ',
            Agendado = 'A',
            Futuro = 'F',
            Conciliado = 'C',
            Reconciliado = 'R'
        }

        public enum ResponsavelTaxa
        {
            Origem,
            Destino
        }

        public enum TipoArquivo
        {
            OFX,
            HitBTC
        }

        public enum FiltroTransferencia
        {
            Todas = 3,
            Origem = 2,
            Destino = 1,
            Nenhuma = 0
        }

        public enum VariacaoTeclado
        {
            Nenhuma = 0,
            Carteira = 1,
            Orcamento = 2,
            FluxoCaixaDisponivel = 3
        }

        public enum TipoFluxoCaixa
        {
            Disponivel,
            Credito
        }
    }
}
