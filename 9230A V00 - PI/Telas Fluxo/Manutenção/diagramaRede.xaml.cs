using System.Windows.Controls;

namespace _9230A_V00___PI.Telas_Fluxo.Manutenção
{
    /// <summary>
    /// Interação lógica para diagramaRede.xam
    /// </summary>
    public partial class diagramaRede : UserControl
    {
        Utilidades.VariaveisGlobais.diagnosticoProfinet _1U1 = new Utilidades.VariaveisGlobais.diagnosticoProfinet();
        Utilidades.VariaveisGlobais.diagnosticoProfinet _2U1 = new Utilidades.VariaveisGlobais.diagnosticoProfinet();
        Utilidades.VariaveisGlobais.diagnosticoProfinet _3U1 = new Utilidades.VariaveisGlobais.diagnosticoProfinet();
        Utilidades.VariaveisGlobais.diagnosticoProfinet _4U1 = new Utilidades.VariaveisGlobais.diagnosticoProfinet();
        Utilidades.VariaveisGlobais.diagnosticoProfinet _5U1 = new Utilidades.VariaveisGlobais.diagnosticoProfinet();
        Utilidades.VariaveisGlobais.diagnosticoProfinet _1U3 = new Utilidades.VariaveisGlobais.diagnosticoProfinet();
        Utilidades.VariaveisGlobais.diagnosticoProfinet _2U3 = new Utilidades.VariaveisGlobais.diagnosticoProfinet();
        Utilidades.VariaveisGlobais.diagnosticoProfinet _3U3 = new Utilidades.VariaveisGlobais.diagnosticoProfinet();
        Utilidades.VariaveisGlobais.diagnosticoProfinet _4U3 = new Utilidades.VariaveisGlobais.diagnosticoProfinet();
        Utilidades.VariaveisGlobais.diagnosticoProfinet _43G1 = new Utilidades.VariaveisGlobais.diagnosticoProfinet();
        Utilidades.VariaveisGlobais.diagnosticoProfinet _62G1 = new Utilidades.VariaveisGlobais.diagnosticoProfinet();
        Utilidades.VariaveisGlobais.diagnosticoProfinet _65G1 = new Utilidades.VariaveisGlobais.diagnosticoProfinet();
        Utilidades.VariaveisGlobais.diagnosticoProfinet _1U2 = new Utilidades.VariaveisGlobais.diagnosticoProfinet();
        Utilidades.VariaveisGlobais.diagnosticoProfinet _2U2 = new Utilidades.VariaveisGlobais.diagnosticoProfinet();


        public diagramaRede()
        {
            InitializeComponent();
        }

        //'Bit 0 - Good
 
        //'Bit 1 - Disabled
 
        //'Bit 2 - Maintenance required
 
        //'Bit 3 - Maintenance demanded
 
        //'Bit 4 - Error
 
        //'Bit 5 - Hardware component not reachable - Hardware component cannot be accessed.
 
        //'Bit 6 - Qualified: Bit 6 = 1 if at least one qualified diagnostics is available
 
        //'Bit 7 - I/O data not available - I/O data not available
 
        //'8 to 14 - Reserved (always = 0)
 
        //'Bit 15 - Network/hardware fault 'S7-1200: Reserved(always = 0) 'S7-1500: If bit 4 = 1 or bit 5 = 1:

        //'Bit 15 = 0: Network error

        //'Bit 15 = 1: Hardware error


        public void atualizaRede(int buffer)
        {
            _1U1 = Utilidades.Move_Bits.WordToDiagnosticoProfinet(Comunicacao.Sharp7.S7.GetWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[buffer].Buffer, 4), _1U1);

            _2U1 = Utilidades.Move_Bits.WordToDiagnosticoProfinet(Comunicacao.Sharp7.S7.GetWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[buffer].Buffer, 6), _2U1);

            _3U1 = Utilidades.Move_Bits.WordToDiagnosticoProfinet(Comunicacao.Sharp7.S7.GetWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[buffer].Buffer, 8), _3U1);

            _4U1 = Utilidades.Move_Bits.WordToDiagnosticoProfinet(Comunicacao.Sharp7.S7.GetWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[buffer].Buffer, 10), _4U1);

            _5U1 = Utilidades.Move_Bits.WordToDiagnosticoProfinet(Comunicacao.Sharp7.S7.GetWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[buffer].Buffer, 12), _5U1);

            _1U3 = Utilidades.Move_Bits.WordToDiagnosticoProfinet(Comunicacao.Sharp7.S7.GetWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[buffer].Buffer, 14), _1U3);

            _2U3 = Utilidades.Move_Bits.WordToDiagnosticoProfinet(Comunicacao.Sharp7.S7.GetWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[buffer].Buffer, 16), _2U3);

            _3U3 = Utilidades.Move_Bits.WordToDiagnosticoProfinet(Comunicacao.Sharp7.S7.GetWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[buffer].Buffer,18), _3U3);

            _4U3 = Utilidades.Move_Bits.WordToDiagnosticoProfinet(Comunicacao.Sharp7.S7.GetWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[buffer].Buffer, 20), _4U3);

            _43G1 = Utilidades.Move_Bits.WordToDiagnosticoProfinet(Comunicacao.Sharp7.S7.GetWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[buffer].Buffer, 22), _43G1);

            _62G1 = Utilidades.Move_Bits.WordToDiagnosticoProfinet(Comunicacao.Sharp7.S7.GetWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[buffer].Buffer,24), _62G1);

            _65G1 = Utilidades.Move_Bits.WordToDiagnosticoProfinet(Comunicacao.Sharp7.S7.GetWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[buffer].Buffer, 26), _65G1);

            _1U2 = Utilidades.Move_Bits.WordToDiagnosticoProfinet(Comunicacao.Sharp7.S7.GetWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[buffer].Buffer, 28), _1U2);

            _2U2 = Utilidades.Move_Bits.WordToDiagnosticoProfinet(Comunicacao.Sharp7.S7.GetWordAt(Utilidades.VariaveisGlobais.Buffer_PLC[buffer].Buffer, 30), _2U2);
        
       
        
        }

        private void atualizaProfinet(Utilidades.VariaveisGlobais.diagnosticoProfinet diagnosticoProfinet) 
        {

            if (diagnosticoProfinet.Good)
            {

            }
            else
            {

            }

        }
    }
}
