using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKP.KRD
{
    public partial class AddCharacterForm : Form
    {
        public AddCharacterForm()
        {
            InitializeComponent();

            
        }

        public void AddCharacter()
        {
            //tworzysz obiekt clienta serwisu

            //przepisujesz wartosci z formatki do CharacterRequest

            //Wywolujesz


            using (var service = new ServiceClient())
            {
                var obj =new SERVICE.()
                {
                    
                };
                service.AddCharacter(OBJ);
            }
        }

      
    }
}
