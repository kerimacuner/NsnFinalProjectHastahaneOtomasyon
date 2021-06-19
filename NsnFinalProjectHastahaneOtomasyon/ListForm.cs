using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NsnFinalProjectHastahaneOtomasyon
{
    public partial class ListForm : Form
    {
        public ListForm()
        {
            InitializeComponent();
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            DbProcess db = new DbProcess();
            DataTable dataTable = db.GetLiDataTable();
            //bool result = db.Login("kerimAcuner", "123456");
            dataGridView1.DataSource = dataTable;
        }
    }
}
