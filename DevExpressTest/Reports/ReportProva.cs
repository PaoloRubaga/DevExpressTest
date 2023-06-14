using DataAccessLibrary.Models;

namespace DevExpressTest.Reports
{
    public partial class ReportProva : DevExpress.XtraReports.UI.XtraReport
    {
        //public ObjectDataSource prova = new ObjectDataSource();
        public ReportProva(List<DispositivoModel> listaDispositivi)
        {
            InitializeComponent();
            //prova.DataSource = listaDispositivi;
            //this.SetDataSource(prova);

            TabellaDispositivi.DataSource = listaDispositivi;
            bool f = false;
        }
    }
}
