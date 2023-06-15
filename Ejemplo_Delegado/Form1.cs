using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Filtro;
using System.Reflection;

namespace Ejemplo_Delegado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] nombres = { "Chiara", "Daniel", "Pedro", "Emiliano", "Guillermo", "Ezequiel", "Lola", "Juana", "Cecilia" };

        public delegate IEnumerable<string> MiDelegado1(string[] pArray, int pCorte);
        
        MiDelegado1 x; 
        private void Form1_Load(object sender, EventArgs e)
        {
           var a = Assembly.GetAssembly(typeof(Filtro.Filtro)).GetTypes();

            foreach (Type t in a)
            {
                var z = t.GetCustomAttribute(typeof(Mostrable));

                if (z != null) 
                {
                    listBox1.Items.Add(new MyItem((z as Mostrable).Leyenda(), t));
                }

            }

        }

        private void Ejecuta(MiDelegado1 pD)
        {
            textBox1.Clear();
            foreach (string s in pD(nombres, Convert.ToInt16(numericUpDown1.Value))) 
            {
                textBox1.Text+= $"{s}{Environment.NewLine}";
            
            }
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            listBox1_SelectedIndexChanged(null, null);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = listBox1.SelectedItem as MyItem; 
            var t = i.Tipo(); 

            var o = t.Assembly.CreateInstance(t.FullName, true, BindingFlags.Default, null, null,null,null);
            MethodInfo m = t.Assembly.GetType(t.FullName).GetMethod("Filtrar");
            Ejecuta((MiDelegado1)m.CreateDelegate(typeof(MiDelegado1), o)); 

        }
    }
}
