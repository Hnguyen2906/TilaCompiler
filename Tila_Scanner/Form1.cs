using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tila_Scanner
{
    public partial class Form1 : Form
    {
        private bool isNeedToAnalyze = false;
        private CancellationTokenSource _tokenSource;
        private Task task;

        public Form1()
        {
            InitializeComponent();
            //default statements
            InputTxt.Text = @"  
                                begin 
                                    int abc; 
                                    abc = (a - 1); 
                                    while x - 1 
                                        do 
                                        begin 
                                            x = 2; 
                                        end; 

                                    print x - 1; 
                                end";
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
                OutputTxt.Text += "\r\n----------------------------------------";
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

        private void AutoBtn_Click(object sender, EventArgs e)
        {
            if (AutoBtn.Text == "Enable AutoSyntaxAnalyzer")
            {
                AutoBtn.Text = "Disable AutoSyntaxAnalyzer";
                TokenConvertBtn.Enabled = false;
                SyntaxBtn.Enabled = false;
                isNeedToAnalyze = true;
            }
            else
            {
                AutoBtn.Text = "Enable AutoSyntaxAnalyzer";
                TokenConvertBtn.Enabled = false;
                SyntaxBtn.Enabled = false;
                isNeedToAnalyze = false;
            }
        }

        private void InputTxt_TextChanged(object sender, EventArgs e)
        {
            if (isNeedToAnalyze)
            {
                DoAnalyzeCode();
            }
        }

        private void DoAnalyzeCode()
        {
            try
            {
                if (task != null && !task.IsCompleted)
                {
                    _tokenSource.Cancel();
                }

                try
                {
                    _tokenSource = new CancellationTokenSource();
                    task = Task.Run(() => 
                                        {
                                            AnalyzeCode(); 
                                            _tokenSource.Token.ThrowIfCancellationRequested(); 
                                        }, _tokenSource.Token);
                }
                catch
                {
                }
            }
            catch
            {

            }
        }

        private void AnalyzeCode()
        {
            try
            {
                TilaScanner scanner = new TilaScanner(InputTxt.Text);

                var outputStream = scanner.ConvertToTokenStream();

                TilaParser parser = new TilaParser(outputStream);
                if (parser.NoSyntaxErrors())
                {
                    OutputTxt.Invoke(new MethodInvoker(delegate { OutputTxt.Text = "No syntax errors!"; }));
                }
                else
                {
                    OutputTxt.Invoke(new MethodInvoker(delegate { OutputTxt.Text = "Syntax error(s) detected!"; }));
                }
            }
            catch (Exception ex)
            {
                OutputTxt.Invoke(new MethodInvoker(delegate { OutputTxt.Text = ex.Message; }));
            }
        }
    }
}
