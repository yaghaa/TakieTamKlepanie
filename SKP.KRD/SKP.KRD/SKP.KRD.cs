using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKP.KRD.Gamification;

namespace SKP.KRD
{
    public partial class SKPKRD : Form
    {
        public SKPKRD()
        {
            InitializeComponent();
        }

        private void bShowAllCharacter_Click(object sender, EventArgs e)
        {
            var repository = new DataAccessRepository();
            dgvCharacters.DataSource = repository.GetCharacters();
        }

        private void bAddCharacter_Click(object sender, EventArgs e)
        {
            var addCharacterForm = new AddCharacterForm();
            addCharacterForm.ShowDialog();
        }
    }
}
