using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CryptLab4PANAMA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void button1encode_Click(object sender, EventArgs e)
        {
            if (textBox1key.Text.Length<32)
            {
                MessageBox.Show("Key too short");
                return;
            }

            if (textBox1param.Text.Length < 32)
            {
                MessageBox.Show("Param too short");
                return;
            }

            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
            if (f.FileName == "") return;

            byte[] key = Encoding.Convert(Encoding.Unicode, Encoding.Default, Encoding.Unicode.GetBytes(textBox1key.Text));
            byte[] param = Encoding.Convert(Encoding.Unicode, Encoding.Default, Encoding.Unicode.GetBytes(textBox1param.Text));

            Panama algo = new Panama();
            algo.InitCipher(Panama.ByteArrToIntArr(key), Panama.ByteArrToIntArr(param));

            byte[] data = File.ReadAllBytes(f.FileName);

            byte[] result = Panama.IntArrToByteArr(algo.EncryptDecrypt(Panama.ByteArrToIntArr(data)));



            if (sender == button1encode)
            {
                File.WriteAllBytes(Path.GetFileNameWithoutExtension(f.FileName) + "_encoded" + Path.GetExtension(f.FileName), result);
            }
            else
            {
                File.WriteAllBytes(Path.GetFileNameWithoutExtension(f.FileName) + "_decoded" + Path.GetExtension(f.FileName), result);
            }
        }

        private void button1hash_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
            if (f.FileName == "") return;

            Panama algo = new Panama();

            byte[] data = File.ReadAllBytes(f.FileName);

            byte[] result = Panama.IntArrToByteArr(algo.Hash(Panama.ByteArrToIntArr(data)));

            result = Encoding.Convert(Encoding.Default, Encoding.Unicode, result);

            textBox1hash.Text = Encoding.Unicode.GetString(result);
        }
    }
}
