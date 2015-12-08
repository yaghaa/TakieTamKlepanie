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

            dgvCharacters.DoubleClick += grid_DoubleClick;
        }

        public void grid_DoubleClick(object sender, EventArgs eventArgs)
        {
            var form = new CharacterDetailsForm((Character)dgvCharacters.CurrentRow.DataBoundItem);
            form.ShowDialog();
        }
        private void bShowAllCharacter_Click(object sender, EventArgs e)
        {
            var repository = new DataAccessRepository();
            var temp = Character.CharactersDefault();
            dgvCharacters.DataSource = temp;
        }

        private void bAddCharacter_Click(object sender, EventArgs e)
        {
            var addCharacterForm = new AddCharacterForm();
            addCharacterForm.ShowDialog();
        }
    }
}
