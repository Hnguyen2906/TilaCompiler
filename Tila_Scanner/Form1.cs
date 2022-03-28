using System;
using System.Windows.Forms;

namespace Tila_Scanner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //InputTxt.Text = "begin int abc; abc = (a - 1); end";
            //InputTxt.Text = "begin int abc; abc = (a - 1); while x = 1 do begin x = 2; end; end";
            InputTxt.Text = "begin " +
                                "while 1 " +
                                    "do " +
                                    "begin " +
                                        "x = 2; " +
                                        "x = 3 " +
                                    "end; " +
                            "end";
        }

        private void TokenConvertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string output = "";
                string additionalText = "\r\nToken list:";
                TilaScanner scanner = new TilaScanner(InputTxt.Text);

                var outputStream = scanner.ConvertToTokenStream();

                foreach (var item in outputStream)
                {
                    output += item.Value;

                    additionalText += "\r\n" + item.Type;
                }

                OutputTxt.Text = output.Trim();
                OutputTxt.Text += additionalText;
            }
            catch (Exception ex)
            {
                OutputTxt.Text = ex.Message;
            }
        }

        private void SyntaxBtn_Click(object sender, EventArgs e)
        {
            try
            {
                TilaScanner scanner = new TilaScanner(InputTxt.Text);

                var outputStream = scanner.ConvertToTokenStream();

                TilaParser parser = new TilaParser(outputStream);
                if (parser.NoSyntaxErrors())
                {
                    OutputTxt.Text = "No syntax errors!";
                }
                else
                {
                    OutputTxt.Text = "Syntax error(s) detected!";
                }
            }
            catch(Exception ex)
            {
                OutputTxt.Text = ex.Message;
            }
        }
    }
}
