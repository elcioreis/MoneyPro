using System.Windows.Forms;

namespace MoneyPro.Base
{
    public partial class fmBaseTopoRodape : MoneyPro.Base.fmBaseSoTopo
    {

        public fmBaseTopoRodape()
        {
            InitializeComponent();
        }

        private void toolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
    }
}
