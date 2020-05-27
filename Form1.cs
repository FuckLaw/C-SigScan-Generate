using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Organizer_SigScan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            txb_generate.Text = "";
            //Adicionei 1 textbox responsável por obter a Pattern, 1 onde vai estar o resultado final, e 1 button para quando ele for clicado a ação acontecer...
            string Mask = "";  // Aqui declaro uma variável que irá obter a Mask durante o percurso...
            var ListPattern = txb_pattern.Text; // Converto os valores da Textbox para Array
            for(int i = 0; i < ListPattern.Length;i+=3)  // Faço um for pulando de 3 em 3 para checar se é um valor válido, digamos "00 55", a distancia do primeiro '0' até o '5 ' é 3
            {
                if(ListPattern[i].ToString() == "?")  // verificamos se o Index é um valor dinâmico, se for, a Mask terá o valor '?'
                   Mask += "?";
                else
                    Mask += "x";  // Caso o valor encontrado for válido, a Mask terá o valor 'x'
            }

            txb_generate.AppendText("\\x"); // Aqui, antes de começarmos o loop, alteramos antes do primeiro byte para '\x', afinal, toda a Array deverá alterar os espaços em branco para '\x'...

            for (int i = 0; i < ListPattern.Length; i++)
            {
                if (ListPattern[i].ToString() == " ") // Aqui verificamos se o Index é um espaço em branco, se for, alteramos para '\x'
                    txb_generate.AppendText("\\x");
                else
                {
                    if(ListPattern[i].ToString() == "?") // Caso o valor for dinâmico, alteramos para '00'
                        txb_generate.AppendText("0");
                    else
                        txb_generate.AppendText(ListPattern[i].ToString()); // Caso seja fixo, adiciona o valor normal...
                }
            }
            txb_generate.AppendText(", " + Mask); // Ao final passamos a Mask logo depois da Pattern.
        }
    }
}
