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
        // Tipo de retorno que usamos en este casoel IEnumerable
        //nombre de mi delegado MiDelegado1
        //la firma es que trabaja con array de string pArray y entero pCorte
        //esto va a ser una especie de filtro donde vamos a filtrar nombres por la cant de caracteres
        //vamos a generar varios tipos de filtros

        MiDelegado1 x; //x variable del tipo miDelegado1 que me sirve mas que nada para:
                       //1. Inyectar esa variable a una funcion pasandosela por parametro a esa funcion
                       //2. poder hacer que x apunte a distintas funciones
                       //RESTRICCION: las funciones a las que x apunta deben tener el tipo de retorno IEnumerable y la misma firma 


        private void Form1_Load(object sender, EventArgs e)
        {
           var a = Assembly.GetAssembly(typeof(Filtro.Filtro)).GetTypes();

            foreach (Type t in a)
            {
                // Recupero el atributo Mostrable del tipo t. Si no lo posee retorno null
                var z = t.GetCustomAttribute(typeof(Mostrable)); //le paso el objeto Type que reprersena los tipos de attributos que quiero recuperar. z va a ser de tipo Attribute

                if (z != null) // si viene quiere decir que el Typo me interesa porque tiene el Attribute personalizado que yo le agregue
                {
                    listBox1.Items.Add(new MyItem((z as Mostrable).Leyenda(), t));
                    //si hay algo es de tipo Mostrable, por lo tanto lo casteo como mostrable porque en Mostrable tengo la leyenda qdel attributo es
                    //el texto que traigo del attributo con (z as Mostrable).Leyenda() se lo mando MyItem
                    //genero ese objeto MyItem y se lo cargo al listBox
                }

            }

        }

        private void Ejecuta(MiDelegado1 pD)
        {
            textBox1.Clear();
            foreach (string s in pD(nombres, Convert.ToInt16(numericUpDown1.Value))) //este devuelve un IEnumerablle
            {
                textBox1.Text+= $"{s}{Environment.NewLine}"; //a esas s las pongo en el textBox y agrego salto de linea entre cada s
            
            }
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            listBox1_SelectedIndexChanged(null, null);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = listBox1.SelectedItem as MyItem; //del listBox agarro el elemento seleccionado y lo casteo a MyItem 
            var t = i.Tipo();  //llamo a una funcion a la cual le paso el Type de lo que recupere en i
            //ya tengo mi objeto Type

            var o = t.Assembly.CreateInstance(t.FullName, true, BindingFlags.Default, null, null,null,null);
            //al tipo t que me recupere el ensamblado y que me cree un objeto con CreateInstance
            //para hacer eso le tengo que pasar el nombre del tipo FullName
            //o es un object
            MethodInfo m = t.Assembly.GetType(t.FullName).GetMethod("Filtrar");

            // Se crea un Delegado que apunta al metodo m del methodInfo y que representa a Filtrar
            // Se pasa a tipo MIDelegado1 y luego de envía a la función Ejecuta
            Ejecuta((MiDelegado1)m.CreateDelegate(typeof(MiDelegado1), o)); //casteo por ejemplo, el o lo hice del tipo FIltroMayorQue o FiltroMenorQue
            //

        }
    }
}
